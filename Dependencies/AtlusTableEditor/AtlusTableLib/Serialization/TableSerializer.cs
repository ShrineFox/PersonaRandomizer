using AtlusLibSharp.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using TGELib.IO;
using TGELib.Reflection;

namespace AtlusTableLib.Serialization
{
    /// <summary>
    /// Provides methods to serialize or deserialize tables from either files or streams.
    /// </summary>
    public class TableSerializer : IDisposable
    {
        private static readonly Type[] sTableTypes;

        static TableSerializer()
        {
            sTableTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetCustomAttribute<TableAttribute>() != null)
                .ToArray();
        }

        /// <summary>
        /// Deserializes the given file specified by <paramref name="path"/> containing a serialized table of type <typeparamref name="TTable"/>.
        /// </summary>
        /// <typeparam name="TTable">The type of the table to deserialize.</typeparam>
        /// <param name="path">A file path pointing to the table file to deserialize.</param>
        /// <returns>A deserialized table instance of type <typeparamref name="TTable"/></returns>
        public static TTable Deserialize<TTable>(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            if (!File.Exists(path))
                throw new ArgumentException("Specified file doesn't exist", nameof(path));

            var tableType = typeof(TTable);
            var tableName = Path.GetFileNameWithoutExtension(path);

            using (var tableStream = File.OpenRead(path))
            using (var serializer = new TableSerializer(tableType, tableStream, tableName))
            {
                return (TTable)serializer.DeserializeTable(false);
            }
        }

        /// <summary>
        /// Deserializes the given stream containing a serialized table of type <typeparamref name="TTable"/>.
        /// </summary>
        /// <remarks>The stream is not disposed after calling this method.</remarks>
        /// <typeparam name="TTable">The type of the table to deserialize.</typeparam>
        /// <param name="stream">A stream containing a serialized table.</param>
        /// <returns>A deserialized table instance of type <typeparamref name="TTable"/></returns>
        public static TTable Deserialize<TTable>(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (stream.Length == 0)
                throw new ArgumentException("Stream cannot be empty.", nameof(stream));

            var tableType = typeof(TTable);

            using (var serializer = new TableSerializer(tableType, stream))
                return (TTable)serializer.DeserializeTable(true);
        }

        /// <summary>
        /// Deserializes the given file specified by <paramref name="path"/> containing a serialized table using the <paramref name="path"/>'s file name and <paramref name="game"/> parameter.
        /// </summary>
        /// <param name="path">A file path pointing to the table file to deserialize.</param>
        /// <param name="game">A <see cref="Game"/> enumeration used to determine the type of the table.</param>
        /// <returns>A deserialized table instance.</returns>
        public static object Deserialize(string path, Game game)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            var name = Path.GetFileNameWithoutExtension(path);
            var type = sTableTypes.Single(x =>
            {
                var attrib = x.GetCustomAttribute<TableAttribute>();
                return attrib.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && attrib.Games.Any(y => y == game);
            });

            using (var tableStream = File.OpenRead(path))
            using (var serializer = new TableSerializer(type, tableStream, name))
                return serializer.DeserializeTable(false);
        }

        /// <summary>
        /// Deserializes the given stream containing a serialized table using the provided <paramref name="name"/> and <paramref name="game"/> parameters.
        /// </summary>
        /// <remarks>The stream is not disposed after calling this method.</remarks>
        /// <param name="stream">A stream containing a serialized table.</param>
        /// <param name="name">The name of the table file to deserialize.</param>
        /// <param name="game">A <see cref="Game"/> enumeration used to determine the type of the table.</param>
        /// <returns>A deserialized table instance.</returns>
        public static object Deserialize(Stream stream, string name, Game game)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            var type = sTableTypes.Single(x =>
            {
                var attrib = x.GetCustomAttribute<TableAttribute>();
                return attrib.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && attrib.Games.Any(y => y == game);
            });

            using (var serializer = new TableSerializer(type, stream, name))
                return serializer.DeserializeTable(true);
        }

        /// <summary>
        /// Serializes the given <paramref name="table"/> in the specified <paramref name="endianness"/> and saves the output to the file specified by <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the table.</typeparam>
        /// <param name="table">The table to be serialized.</param>
        /// <param name="path">The path to the file to save the output to.</param>
        /// <param name="endianness">The endianness in which to write the output with.</param>
        public static void Serialize<T>(T table, string path, Endianness endianness = Endianness.LittleEndian)
        {
            var tableType = typeof(T);

            using (var fileStream = File.OpenWrite(path))
            using (var serializer = new TableSerializer(tableType, fileStream))
            {
                serializer.SerializeTable(tableType, table, endianness, false);
            }
        }

        /// <summary>
        /// Serializes the given <paramref name="table"/> in the specified <paramref name="endianness"/> and saves the output the given <paramref name="stream"/>.
        /// </summary>
        /// <remarks>The stream is not disposed after calling this method.</remarks>
        /// <typeparam name="T">The type of the table.</typeparam>
        /// <param name="table">The table to be serialized.</param>
        /// <param name="stream">The stream save the output to.</param>
        /// <param name="endianness">The endianness in which to write the output with.</param>
        public static void Serialize<T>(T table, Stream stream, Endianness endianness = Endianness.LittleEndian)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var tableType = typeof(T);
            var serializer = new TableSerializer(tableType, stream);
            serializer.SerializeTable(tableType, table, endianness, true);
        }

        /// <summary>
        /// Serializes the given <paramref name="table"/> in the specified <paramref name="endianness"/> and saves the output to the file specified by <paramref name="path"/>.
        /// </summary>
        /// <param name="table">The table to be serialized.</param>
        /// <param name="path">The path to the file to save the output to.</param>
        /// <param name="endianness">The endianness in which to write the output with.</param>
        public static void Serialize(object table, string path, Endianness endianness = Endianness.LittleEndian)
        {
            var tableType = table.GetType();

            using (var fileStream = File.OpenWrite(path))
            using (var serializer = new TableSerializer(tableType, fileStream))
            {
                serializer.SerializeTable(tableType, table, endianness, false);
            }
        }

        /// <summary>
        /// Serializes the given <paramref name="table"/> in the specified <paramref name="endianness"/> and saves the output the given <paramref name="stream"/>.
        /// </summary>
        /// <remarks>The stream is not disposed after calling this method.</remarks>
        /// <param name="table">The table to be serialized.</param>
        /// <param name="stream">The stream save the output to.</param>
        /// <param name="endianness">The endianness in which to write the output with.</param>
        public static void Serialize(object table, Stream stream, Endianness endianness = Endianness.LittleEndian)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var tableType = table.GetType();
            var serializer = new TableSerializer(tableType, stream);
            serializer.SerializeTable(tableType, table, endianness, true);
        }

        private readonly Type mTableType;
        private readonly Stream mTableStream;
        private EndianBinaryReader mReader;
        private EndianBinaryWriter mWriter;

        private TableSerializer(Type type, Stream stream, string name = null)
        {
            if (type.GetCustomAttribute<TableAttribute>() == null)
                throw new Exception("Type must be a table");

            mTableType = type;
            mTableStream = stream;
        }

        private static IEnumerable<MemberInfo> GetSortedMembers(Type type)
        {
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            var tableMembers = members.Where(x => x.GetCustomAttribute<TableMemberAttribute>() != null);
            var tableMembersSorted = tableMembers.OrderBy(x => x.GetCustomAttribute<TableMemberAttribute>().LineNumber);

            return tableMembersSorted;
        }

        #region Deserialization

        private object DeserializeTable(bool leaveOpen)
        {
            mReader = new EndianBinaryReader(mTableStream, Encoding.Default, leaveOpen, Endianness.LittleEndian);

            return DeserializeClassOrValueType(mTableType);
        }

        private object DeserializeClassOrValueType(Type type)
        {
            var instance = Activator.CreateInstance(type);

            foreach (var member in GetSortedMembers(type))
            {
                var tableMemberAttribute = member.GetCustomAttribute<TableMemberAttribute>();

                switch (tableMemberAttribute.MemberType)
                {
                    case TableMemberType.FieldOrProperty:
                        DeserializeMember(instance, member, tableMemberAttribute);
                        break;

                    case TableMemberType.Segment:
                        DeserializeSegment(instance, member, tableMemberAttribute);
                        break;

                    case TableMemberType.VariableLengthStringSegmentPair:
                        DeserializeVariableLengthStringSegmentPair(instance, member, tableMemberAttribute);
                        break;
                }
            }

            return instance;
        }

        private void DeserializeSegment(object instance, MemberInfo memberInfo, TableMemberAttribute attribute)
        {
            int segmentLength = ReadSegmentLength();
            long segmentEnd = mReader.Position + segmentLength;

            DeserializeMember(instance, memberInfo, attribute, segmentLength);

            if (mReader.Position < segmentEnd)
            {
                throw new Exception("Not enough data read from table segment");
            }
            else if (mReader.Position > segmentEnd)
            {
                throw new Exception("Read past end of table segment");
            }

            mReader.Position = AlignmentHelper.Align(mReader.Position, 16);
        }

        private void DeserializeMember(object instance, MemberInfo memberInfo, TableMemberAttribute attribute, int segmentLength = -1)
        {
            var type = memberInfo.GetMemberType();
            memberInfo.SetValue(instance, DeserializeType(type, attribute, segmentLength));
        }

        private object DeserializeType(Type type, TableMemberAttribute attribute, int segmentLength = -1)
        {
            if (type.IsPrimitive)
            {
                return DeserializePrimitive(type);
            }
            else if (type.IsEnum)
            {
                var underlyingType = type.GetEnumUnderlyingType();
                return Enum.ToObject(type, DeserializePrimitive(underlyingType));
            }
            else if (type.IsArray)
            {
                return DeserializeArray(type, attribute, segmentLength);
            }
            else if (type.IsClass || type.IsValueType)
            {
                if (type == typeof(string))
                {
                    return DeserializeString(attribute);
                }
                else
                {
                    return DeserializeClassOrValueType(type);
                }
            }
            else
            {
                throw new NotImplementedException("Type not implemented");
            }
        }

        private string DeserializeString(TableMemberAttribute attribute)
        {
            if (attribute.FixedStringLength == -1)
                throw new Exception("Fixed string length must be specified");

            var bytes = mReader.ReadBytes(attribute.FixedStringLength);
            var str = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0)
                    break;

                if (bytes[i] >= 0x80)
                {
                    str += (char) (bytes[i++] | bytes[i] << 8);
                }
                else
                {
                    str += (char)bytes[i];
                }
            }

            mReader.SeekCurrent(1);

            /*
            var bytes = mReader.ReadBytes(attribute.FixedStringLength);
            var str = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0)
                    break;

                if (bytes[i] >= 0x80)
                {
                    str += TextEncoding.GetCharacter((ushort) (bytes[i++] << 8 | bytes[i]));
                }
                else
                {
                    str += TextEncoding.GetCharacter(bytes[i]);
                }
            }
            */

            return str;
        }

        private Array DeserializeArray(Type type, TableMemberAttribute attribute, int segmentLength = -1)
        {
            var elementType = type.GetElementType();
            int elementCount = attribute.FixedArrayLength;

            if (elementCount == -1 && attribute.MemberType == TableMemberType.Segment)
            {
                if (segmentLength == -1)
                    throw new ArgumentOutOfRangeException(nameof(segmentLength), "Segment length should be equal to or more than 0");

                if (!elementType.IsPrimitive)
                    throw new Exception("A segment with implicit array length must be of a primitive type");

                int elementSize = Marshal.SizeOf(elementType);
                elementCount = segmentLength / elementSize;
            }

            if (elementType.IsPrimitive)
            {
                return DeserializePrimitiveArray(elementType, elementCount);
            }
            else if (elementType.IsEnum)
            {
                var array = DeserializePrimitiveArray(elementType.GetEnumUnderlyingType(), elementCount);
                var array2 = Array.CreateInstance(elementType, elementCount);
                for (int i = 0; i < array.Length; i++)
                    array2.SetValue(Enum.ToObject(elementType, array.GetValue(i)), i);

                return array2;
            }
            else
            {
                return DeserializeComplexArray(elementType, attribute, elementCount);
            }
        }

        private Array DeserializePrimitiveArray(Type elementType, int elementCount)
        {
            switch (Type.GetTypeCode(elementType))
            {
                case TypeCode.Boolean: return mReader.ReadBooleans(elementCount);
                case TypeCode.Char: return mReader.ReadChars(elementCount);
                case TypeCode.SByte: return mReader.ReadSBytes(elementCount);
                case TypeCode.Byte: return mReader.ReadBytes(elementCount);
                case TypeCode.Int16: return mReader.ReadInt16s(elementCount);
                case TypeCode.UInt16: return mReader.ReadUInt16s(elementCount);
                case TypeCode.Int32: return mReader.ReadInt32s(elementCount);
                case TypeCode.UInt32: return mReader.ReadUInt32s(elementCount);
                case TypeCode.Int64: return mReader.ReadInt64s(elementCount);
                case TypeCode.UInt64: return mReader.ReadUInt64s(elementCount);
                case TypeCode.Single: return mReader.ReadSingles(elementCount);
                case TypeCode.Double: return mReader.ReadDoubles(elementCount);

                default:
                    throw new NotImplementedException();
            }
        }

        private Array DeserializeComplexArray(Type elementType, TableMemberAttribute attribute, int elementCount)
        {
            Array array = Array.CreateInstance(elementType, elementCount);

            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(DeserializeType(elementType, attribute), i);
            }

            return array;
        }

        private object DeserializePrimitive(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return mReader.ReadBoolean();
                case TypeCode.Char:    return mReader.ReadChar();
                case TypeCode.SByte:   return mReader.ReadSByte();
                case TypeCode.Byte:    return mReader.ReadByte();
                case TypeCode.Int16:   return mReader.ReadInt16();
                case TypeCode.UInt16:  return mReader.ReadUInt16();
                case TypeCode.Int32:   return mReader.ReadInt32();
                case TypeCode.UInt32:  return mReader.ReadUInt32();
                case TypeCode.Int64:   return mReader.ReadInt64();
                case TypeCode.UInt64:  return mReader.ReadUInt64();
                case TypeCode.Single:  return mReader.ReadSingle();
                case TypeCode.Double:  return mReader.ReadDouble();

                default:
                    throw new NotSupportedException();
            }
        }

        private void DeserializeVariableLengthStringSegmentPair(object instance, MemberInfo memberInfo, TableMemberAttribute attribute)
        {
            int segmentLength = ReadSegmentLength();
            var indices = mReader.ReadInt16s(segmentLength / sizeof(short));
            mReader.Position = AlignmentHelper.Align(mReader.Position, 16);

            segmentLength = ReadSegmentLength();
            var bytes = mReader.ReadBytes(segmentLength);
            mReader.Position = AlignmentHelper.Align(mReader.Position, 16);

            var stringBuilder = new StringBuilder(bytes.Length);
            var strings = new string[indices.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                int byteIndex = indices[i];
                while (true)
                {
                    if (bytes[byteIndex] == 0)
                        break;

                    if (bytes[byteIndex] >= 0x80)
                    {
                        stringBuilder.Append((char) (bytes[byteIndex++] | bytes[byteIndex] << 8));
                    }
                    else
                    {
                        stringBuilder.Append((char) bytes[byteIndex]);
                    }

                    byteIndex++;
                }

                strings[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }

            memberInfo.SetValue(instance, strings);
        }

        private int ReadSegmentLength()
        {
            int segmentLength = mReader.ReadInt32();
            if (segmentLength > mReader.BaseStreamLength || segmentLength < 0)
            {
                mReader.Endianness = mReader.Endianness == Endianness.LittleEndian
                    ? Endianness.BigEndian
                    : Endianness.LittleEndian;

                segmentLength = EndiannessHelper.Swap(segmentLength);
            }

            return segmentLength;
        }

        #endregion

        #region Serialization

        private void SerializeTable(Type type, object instance, Endianness endianness, bool leaveOpen)
        {
            mWriter = new EndianBinaryWriter(mTableStream, Encoding.Default, leaveOpen, endianness);
            SerializeClassOrValueType(type, instance);
        }

        private void SerializeClassOrValueType(Type type, object instance)
        {
            foreach (var member in GetSortedMembers(type))
            {
                var tableMemberAttribute = member.GetCustomAttribute<TableMemberAttribute>();

                switch (tableMemberAttribute.MemberType)
                {
                    case TableMemberType.FieldOrProperty:
                        SerializeMember(instance, member, tableMemberAttribute);
                        break;

                    case TableMemberType.Segment:
                        SerializeSegment(instance, member, tableMemberAttribute);
                        break;

                    case TableMemberType.VariableLengthStringSegmentPair:
                        SerializeVariableLengthStringSegmentPair(instance, member, tableMemberAttribute);
                        break;
                }
            }
        }

        private void SerializeSegment(object instance, MemberInfo memberInfo, TableMemberAttribute attribute)
        {
            // save position & write dummy value
            mWriter.EnqueuePosition();
            mWriter.Write((int)0);

            // write segment data
            SerializeMember(instance, memberInfo, attribute);

            // save end position for calculating segment length & continuing 
            mWriter.EnqueuePosition();

            // seek back to write the segment length
            mWriter.SeekBeginToDequeuedPosition();
            mWriter.Write((int)((mWriter.PeekEnqueuedPosition() - mWriter.BaseStream.Position) - 4));

            // seek back to continue writing
            mWriter.SeekBeginToDequeuedPosition();

            // write alignment padding
            WriteSegmentPadding();
        }

        private void SerializeMember(object instance, MemberInfo memberInfo, TableMemberAttribute attribute)
        {
            var type = memberInfo.GetMemberType();
            var value = memberInfo.GetValue<object>(instance);

            SerializeType(type, value, attribute);
        }

        private void SerializeType(Type type, object value, TableMemberAttribute attribute)
        {
            if (type.IsPrimitive)
            {
                SerializePrimitive(type, value);
            }
            else if (type.IsEnum)
            {
                var underlyingType = type.GetEnumUnderlyingType();
                SerializeType(underlyingType, value, attribute);
            }
            else if (type.IsArray)
            {
                SerializeArray(type, (Array)value, attribute);
            }
            else if (type.IsClass || type.IsValueType)
            {
                if (type == typeof(string))
                {
                    SerializeString((string)value, attribute);
                }
                else
                {
                    SerializeClassOrValueType(type, value);
                }
            }
            else
            {
                throw new NotImplementedException("Type not implemented");
            }
        }

        private void SerializePrimitive(Type type, object value)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: mWriter.Write((bool)value); break;
                case TypeCode.Char: mWriter.Write((char)value); break;
                case TypeCode.SByte: mWriter.Write((sbyte)value); break;
                case TypeCode.Byte: mWriter.Write((byte)value); break;
                case TypeCode.Int16: mWriter.Write((short)value); break;
                case TypeCode.UInt16: mWriter.Write((ushort)value); break;
                case TypeCode.Int32: mWriter.Write((int)value); break;
                case TypeCode.UInt32: mWriter.Write((uint)value); break;
                case TypeCode.Int64: mWriter.Write((long)value); break;
                case TypeCode.UInt64: mWriter.Write((ulong)value); break;
                case TypeCode.Single: mWriter.Write((float)value); break;
                case TypeCode.Double: mWriter.Write((double) value); break;

                default:
                    throw new NotSupportedException();
            }
        }

        private void SerializeArray(Type type, Array array, TableMemberAttribute attribute)
        {
            var elementType = type.GetElementType();

            for (int i = 0; i < array.Length; i++)
            {
                SerializeType(elementType, array.GetValue(i), attribute);
            }
        }

        private void SerializeString(string value, TableMemberAttribute attribute)
        {
            if (attribute.FixedStringLength == -1)
                throw new Exception("Fixed string length must be specified");

            var bytes = Encoding.Unicode.GetBytes(value);
            int bytesWritten = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytesWritten == attribute.FixedStringLength)
                    break;

                /*
                if (bytes[i] >= 0x80)
                {
                    mWriter.Write(bytes[i++]);
                    mWriter.Write(bytes[i]);
                    bytesWritten += 2;
                }
                else
                {
                */
                    mWriter.Write(bytes[i++]);
                    bytesWritten += 1;
                //}
            }

            int leftOver = (attribute.FixedStringLength + 1) - bytesWritten;

            while (leftOver > 0)
            {
                mWriter.Write((byte) 0);
                leftOver--;
            }

            /*
            int bytesWritten = 0;
            for (int i = 0; i < value.Length; i++)
            {
                ushort characterCode = TextEncoding.GetCharacterCode(value[i]);
                if (characterCode <= 0x7F)
                {
                    mWriter.Write((byte) (characterCode & 0x00FF));
                    bytesWritten += 1;
                }
                else
                {
                    mWriter.Write((byte) (characterCode & 0xFF00));
                    mWriter.Write((byte) (characterCode & 0x00FF));
                    bytesWritten += 2;
                }
            }

            int leftOver = attribute.FixedStringLength - bytesWritten;
            while (leftOver-- > 0)
                mWriter.Write((byte)0);
                */

        }

        private void SerializeVariableLengthStringSegmentPair(object instance, MemberInfo memberInfo,
            TableMemberAttribute attribute)
        {
            // get strings from the field or property
            var strings = memberInfo.GetValue<string[]>(instance);

            // calculate the size of the index buffer and write it to the stream
            int indexBufferSize = strings.Length * sizeof(short);
            mWriter.Write(indexBufferSize);

            // calculate the size of the string buffer while also writing out the 
            // start index of each individual string
            int stringBufferSize = 0;
            foreach (var s in strings)
            {
                // write the starting index of each string
                mWriter.Write((short)stringBufferSize);

                foreach (char c in s)
                {
                    if (c >= 0x80)
                        stringBufferSize += 2;
                    else
                        stringBufferSize += 1;
                }

                // 0 terminator
                stringBufferSize += 1;
            }

            // write padding
            WriteSegmentPadding();

            // write the size of the string buffer
            mWriter.Write(stringBufferSize);

            foreach (var s in strings)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] >= 0x80)
                    {                    
                        mWriter.Write((byte) (s[i] & 0x00FF));
                        mWriter.Write((byte)((s[i] & 0xFF00) >> 8));
                    }
                    else
                    {
                        mWriter.Write((byte)(s[i] & 0x00FF));
                    }
                }

                mWriter.Write((byte) 0);
            }

            // write padding
            WriteSegmentPadding();
        }

        private void WriteSegmentPadding()
        {
            int numPadBytes = AlignmentHelper.GetAlignedDifference(mWriter.Position, 16);
            while (numPadBytes-- > 0)
                mWriter.Write((byte)0);
        }

        #endregion

        void IDisposable.Dispose()
        {
            mReader?.Dispose();
            mWriter?.Dispose();
        }
    }
}
