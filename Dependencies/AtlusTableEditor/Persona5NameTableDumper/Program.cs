using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using AtlusTableLib;
using AtlusTableLib.Serialization;
using TGELib.IO;

namespace AtlusNameTableDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Path to .TBL or folder containing decompiled .txt files: ");
            string path = Console.ReadLine();

            if (File.Exists(path) && Path.GetExtension(path).ToUpper() == ".TBL")
            {
                var table = TableSerializer.Deserialize(path, (Game)Enum.Parse(typeof(Game), "Persona5PS3EU"));
                DumpNameTable(table, Path.GetDirectoryName(path));
            }
            else if (Directory.Exists(path))
            {
                List<string> nameTypes = new List<string> { "ArcanaNames", "SkillNames", "UnitNames", "PersonaNames", "AccessoryNames", "ArmorNames",
                    "ConsumableItemNames", "KeyItemNames", "MaterialNames", "MeleeWeaponNames", "BattleActionNames", "OutfitNames", "SkillCardNames", "ConfidantNames", "PartyMemberLastNames", "PartyMemberFirstNames", "RangedWeaponNames",};
                using (FileStream fs = File.Create(Path.Combine(path, "newName.tbl")))
                    using (EndianBinaryWriter bw = new EndianBinaryWriter(fs, Endianness.BigEndian))
                {
                    foreach (string nameType in nameTypes)
                    {
                        int[] tableDataOffsets = UpdateNameTable($"{path}\\{nameType}.txt", out byte[] tableData);
                        
                        //Write size & offsets and pad by 16-byte alignment
                        bw.Write(tableDataOffsets.Count() * 2);
                        byte offsetFiller = 0x00;
                        bw.Write(offsetFiller);
                        bw.Write(offsetFiller);
                        for (int i = 0; i < tableDataOffsets.Count() - 1; i++)
                        {
                            bw.Write(Convert.ToUInt16(tableDataOffsets[i]));
                        }
                        byte[] filler = new byte[AlignmentHelper.GetAlignedDifference(bw.Position, 16)];
                        bw.Write(filler);
                        //Write size & names and pad by 16-byte alignment
                        bw.Write(tableData.Length);
                        bw.Write(tableData);
                        filler = new byte[AlignmentHelper.GetAlignedDifference(bw.Position, 16)];
                        bw.Write(filler);
                    }
                }
            }
        }

        public static int[] UpdateNameTable(string path, out byte[] tableDataArray)
        {
            List<byte> tableData = new List<byte>();
            List<int> tableOffsets = new List<int>();

            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Any(c => c > 255))
                {
                    foreach (char character in line)
                    {
                        if (character > 255)
                        {
                            foreach (byte charByte in Encoding.Unicode.GetBytes(character.ToString()))
                            {
                                tableData.Add(charByte);
                            }
                        }
                        else
                        {
                            foreach (byte charByte in Encoding.ASCII.GetBytes(character.ToString()))
                            {
                                tableData.Add(charByte);
                            }
                        }
                    }
                }
                else
                {
                    foreach (byte nameByte in Encoding.ASCII.GetBytes(line))
                    {
                        tableData.Add(nameByte);
                    }
                }
                
                tableData.Add(0x00);
                tableOffsets.Add(tableData.Count());
            }

            tableDataArray = tableData.ToArray();
            return tableOffsets.ToArray();
        }

        static void DumpNameTable(object table, string directorypath)
        {
            var type = table.GetType();
            var stringArrayProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.GetCustomAttribute<TableMemberAttribute>() != null && x.PropertyType == typeof(string[]));

            foreach (var property in stringArrayProperties)
            {
                WriteStringArrayToFile((string[]) property.GetValue(table), Path.Combine(directorypath, property.Name + ".txt"));
            }
        }

        static void WriteStringArrayToFile(string[] strings, string filename)
        {
            using (var writer = new StreamWriter(File.Create(filename), Encoding.GetEncoding("utf-16")))
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    const int MaxAnsiCode = 255;
                    string line = strings[i];
                    if (line.Any(c => c > MaxAnsiCode))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (char character in line)
                        {
                            if (character > 255)
                            {
                                byte[] charBytes = Encoding.Unicode.GetBytes(character.ToString());
                                foreach(byte charByte in charBytes)
                                {
                                    sb.Append($"[");
                                    sb.AppendFormat("{0:x2}", charByte);
                                    sb.Append($"]");
                                }
                            }
                            else
                            {
                                sb.Append(character);
                            }
                        }
                        //line = sb.ToString();
                    }
                    writer.WriteLine($"{line}");
                }
            }
        }
    }
}
