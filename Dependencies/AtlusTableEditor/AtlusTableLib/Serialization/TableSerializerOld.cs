using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TGELib.IO;
using TGELib.Reflection;

namespace AtlusTableLib.Serialization
{
    public class TableSerializer
    {
        public T Deserialize<T>(string filepath)
        {
            var tableType = typeof(T);
            var tableObj = Activator.CreateInstance(tableType);

            using (var reader = new EndianBinaryReader(File.OpenRead(filepath), GetEndianness(tableType)))
            {
                DeserializeTable(reader, tableObj, tableType);
            }

            return (T)tableObj;
        }

        public void Serialize<T>(T table, string filepath)
        {
            var tableType = typeof(T);

            using (var writer = new EndianBinaryWriter(File.Create(filepath), GetEndianness(tableType)))
            {
                SerializeTable(writer, table, tableType);
            }
        }

        // Helper methods
        private Endianness GetEndianness(Type type)
        {
            var attrib = type.GetCustomAttribute<EndiannessAttribute>();
            if (attrib == null)
                throw new Exception();

            return attrib.Endianness;
        }

        private PropertyInfo[] GetSortedProperties(Type type)
        {
            PropertyInfo[] unsortedProps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return unsortedProps.OrderBy(
                x => x.GetCustomAttribute<TableMemberAttribute>().GetIndex(type))
                .ToArray();
        }

        // Deserialization methods
        private void DeserializeTable(EndianBinaryReader reader, object tableObj, Type type)
        {
            foreach (var property in GetSortedProperties(type))
            {
                // Each property resides in a table segment
                int segmentLength = reader.ReadInt32();

                using (var segmentStream = new MemoryStream(reader.ReadBytes(segmentLength)))
                using (var segmentReader = new EndianBinaryReader(segmentStream, reader.Endianness))
                {
                    DeserializeProperty(segmentReader, tableObj, property);
                }

                // Align to next multiple of 16
                reader.BaseStream.Position = (reader.BaseStream.Position + 15) & ~15;
            }
        }

        private void DeserializeProperty(EndianBinaryReader reader, object declaringObj, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            object propertyValue = null;

            if (propertyType == typeof(TableSegment))
            {
                propertyValue = new TableSegment(((MemoryStream)reader.BaseStream).ToArray());
            }
            else if (propertyType.IsArray)
            {
                var fixedLengthAttrib = property.GetCustomAttribute<FixedArrayLengthAttribute>();
                if (fixedLengthAttrib == null)
                    throw new Exception();

                if (propertyType == typeof(string[]))
                {
                    var fixedStrLengthAttrib = property.GetCustomAttribute<FixedStringLengthAttribute>();
                    if (fixedStrLengthAttrib == null)
                        throw new Exception();

                    string[] strings = new string[fixedLengthAttrib.Length];

                    for (int i = 0; i < strings.Length; i++)
                    {
                        unsafe
                        {
                            fixed (sbyte* pBytes = (sbyte[])DeserializeArray(reader, fixedStrLengthAttrib.Length, typeof(sbyte)))
                            {
                                strings[i] = new string(pBytes);
                            }
                        }
                    }

                    propertyValue = strings;
                }
                else
                {
                    propertyValue = DeserializeArray(reader, fixedLengthAttrib.Length, propertyType.GetElementType());
                }
            }
            else
            {
                propertyValue = DeserializeType(reader, propertyType);
            }

            property.SetValue(declaringObj, propertyValue);
        }

        private Array DeserializeArray(EndianBinaryReader reader, int length, Type elementType)
        {
            Array array = Array.CreateInstance(elementType, length);

            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(DeserializeType(reader, elementType), i);
            }

            return array;
        }

        private object DeserializeType(EndianBinaryReader reader, Type type)
        {
            if (type.IsEnum)
            {
                var underlyingType = type.GetEnumUnderlyingType();
                return Convert.ChangeType(DeserializePrimitive(reader, underlyingType), type);
            }
            if (type.IsPrimitive)
            {
                return DeserializePrimitive(reader, type);
            }
            if (type.IsValueType || type.IsClass)
            {
                object obj = Activator.CreateInstance(type);
                DeserializeStruct(reader, obj, type);
                return obj;
            }
            throw new NotSupportedException();
        }

        private object DeserializePrimitive(EndianBinaryReader reader, Type primitiveType)
        {
            switch (Type.GetTypeCode(primitiveType))
            {
                case TypeCode.Boolean:
                    return reader.ReadBoolean();

                case TypeCode.Char:
                    return reader.ReadChar();

                case TypeCode.SByte:
                    return reader.ReadSByte();

                case TypeCode.Byte:
                    return reader.ReadByte();

                case TypeCode.Int16:
                    return reader.ReadInt16();

                case TypeCode.UInt16:
                    return reader.ReadUInt16();

                case TypeCode.Int32:
                    return reader.ReadInt32();

                case TypeCode.UInt32:
                    return reader.ReadUInt32();

                case TypeCode.Int64:
                    return reader.ReadInt64();

                case TypeCode.UInt64:
                    return reader.ReadUInt64();

                case TypeCode.Single:
                    return reader.ReadSingle();

                case TypeCode.Double:
                    return reader.ReadDouble();

                case TypeCode.Decimal:
                    return reader.ReadDecimal();

                case TypeCode.String:
                    return reader.ReadString();

                default:
                    throw new NotSupportedException();
            }
        }

        private void DeserializeStruct(EndianBinaryReader reader, object declaringObj, Type type)
        {
            foreach (var property in GetSortedProperties(type))
            {
                DeserializeProperty(reader, declaringObj, property);
            }
        }

        // Serialization methods
        private void SerializeTable<T>(EndianBinaryWriter writer, T table, Type type)
        {
            foreach (var property in GetSortedProperties(type))
            {
                // Each property resides in a table segment
                using (var segmentStream = new MemoryStream())
                using (var segmentWriter = new EndianBinaryWriter(segmentStream, writer.Endianness))
                {
                    SerializeProperty(segmentWriter, table, property);

                    // Write segment to stream
                    writer.Write((int)segmentStream.Length);
                    segmentStream.WriteTo(writer.BaseStream);
                }
                
                // Align to next multiple of 16
                long alignedPosition = (writer.BaseStream.Position + 15) & ~15;
                while (writer.BaseStream.Position != alignedPosition)
                    writer.Write((byte)0);
            }
        }

        private void SerializeProperty<T>(EndianBinaryWriter writer, T table, MemberInfo memberInfo)
        {
            var propertyType = memberInfo.DeclaringType;

            if (propertyType == typeof(TableSegment))
            {
                writer.Write(memberInfo.GetValue<TableSegment>(table).Data);
            }
            else if (propertyType.IsArray)
            {
                if (propertyType == typeof(string[]))
                {
                    var fixedStrLengthAttrib = memberInfo.GetCustomAttribute<FixedStringLengthAttribute>();
                    if (fixedStrLengthAttrib == null)
                        throw new Exception();

                    string[] strings = memberInfo.GetValue<string[]>(table);
                    for (int i = 0; i < strings.Length; i++)
                    {
                        SerializeArray(writer, Encoding.ASCII.GetBytes(strings[i]), typeof(byte));

                        // Write padding 
                        for (int j = 0; j < fixedStrLengthAttrib.Length - strings[i].Length; j++)
                            writer.Write((byte)0);
                    }
                }
                else
                {
                    SerializeArray(writer, memberInfo.GetValue<Array>(table), propertyType.GetElementType());
                }
            }
            else
            {
                SerializeType(writer, memberInfo.GetValue<T>(table), propertyType);
            }
        }

        private void SerializeArray(EndianBinaryWriter writer, Array array, Type elementType)
        {
            for (int i = 0; i < array.Length; i++)
            {
                SerializeType(writer, array.GetValue(i), elementType);
            }
        }

        private void SerializeType(EndianBinaryWriter writer, object obj, Type type)
        {
            if (type.IsEnum)
            {
                var underlyingType = type.GetEnumUnderlyingType();
                SerializePrimitive(writer, Convert.ChangeType(obj, underlyingType), underlyingType);
            }
            else if (type.IsPrimitive)
            {
                SerializePrimitive(writer, obj, type);
            }
            else if (type.IsValueType || type.IsClass)
            {
                SerializeStruct(writer, obj, type);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private void SerializePrimitive(EndianBinaryWriter writer, object obj, Type primitiveType)
        {
            switch (Type.GetTypeCode(primitiveType))
            {
                case TypeCode.Boolean:
                    writer.Write((bool)obj); break;

                case TypeCode.Char:
                    writer.Write((char)obj); break;

                case TypeCode.SByte:
                    writer.Write((sbyte)obj); break;

                case TypeCode.Byte:
                    writer.Write((byte)obj); break;

                case TypeCode.Int16:
                    writer.Write((short)obj); break;

                case TypeCode.UInt16:
                    writer.Write((ushort)obj); break;

                case TypeCode.Int32:
                    writer.Write((int)obj); break;

                case TypeCode.UInt32:
                    writer.Write((ushort)obj); break;

                case TypeCode.Int64:
                    writer.Write((long)obj); break;

                case TypeCode.UInt64:
                    writer.Write((ulong)obj); break;

                case TypeCode.Single:
                    writer.Write((float)obj); break;

                case TypeCode.Double:
                    writer.Write((double)obj); break;

                case TypeCode.Decimal:
                    writer.Write((decimal)obj); break;

                case TypeCode.String:
                    writer.Write((string)obj); break;

                default:
                    throw new NotSupportedException();
            }
        }

        private void SerializeStruct(EndianBinaryWriter writer, object obj, Type type)
        {
            foreach (var property in GetSortedProperties(type))
            {
                SerializeProperty(writer, obj, property);
            }
        }
    }
}
