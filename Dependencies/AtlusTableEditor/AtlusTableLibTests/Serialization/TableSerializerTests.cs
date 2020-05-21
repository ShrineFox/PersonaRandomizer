using AtlusTableLib.Serialization;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TGELib.IO;

namespace AtlusTableLib.Serialization.Tests
{
    [TestClass()]
    public class TableSerializerTests
    {
        private static void DeserializeAndSerialize_BinariesShouldBeIdentical_Base<T>(string path, Endianness endianness = Endianness.LittleEndian)
        {
            using (var fileStream = File.OpenRead(path))
            {
                var table = TableSerializer.Deserialize<T>(fileStream);

                using (var memoryStream = new MemoryStream())
                {
                    TableSerializer.Serialize(table, memoryStream, endianness);

                    try
                    {
                        using (var test = File.Create("test"))
                        {
                            memoryStream.Position = 0;
                            memoryStream.CopyTo(test);
                        }

                        fileStream.Position = 0;
                        memoryStream.Position = 0;

                        for (int i = 0; i < memoryStream.Length; i++)
                        {
                            Assert.AreEqual(fileStream.ReadByte(), memoryStream.ReadByte(),
                                $"Different byte at {i:X4}");
                        }

                    }
                    finally
                    {
                        File.Delete("test");
                    }
                }
            }
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_AICALC()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.AICalculationTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\AICALC.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_AICALC_F()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.AICalculationTableF>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\AICALC_F.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_EFFECT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.EffectTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\EFFECT.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_ENCOUNT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.EncounterTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\ENCOUNT.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_ENCOUNT_F()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.EncounterTableF>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\ENCOUNT_F.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_MODEL()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.ModelTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\MODEL.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_MSG()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.MessageTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\MSG.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_PERSONA()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.PersonaTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\PERSONA.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_PERSONA_F()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.PersonaTableF>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\PERSONA_F.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_SKILL()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.SkillTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\SKILL.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_SKILL_F()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.SkillTableF>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\SKILL_F.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_UNIT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.UnitTable>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\UNIT.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona3FES_UNIT_F()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona3FES.UnitTableF>(
                @"D:\Modding\Persona 3 & 4\Persona3\CVM_BTL\BATTLE\UNIT.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_AICALC()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.AICalculationTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\AICALC.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_ENCOUNT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.EncounterTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\ENCOUNT.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_MODEL()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.ModelTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\MODEL.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_MSG()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.MessageTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\MSG.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_PERSONA()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.PersonaTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\PERSONA.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_SKILL()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.SkillTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\SKILL.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona4_UNIT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona4.UnitTable>(
                @"D:\Modding\Persona 3 & 4\Persona4\CVM_BTL\BATTLE\UNIT.TBL");
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_AICALC()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.AICalculationTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\AICALC.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_ELSAI()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.ElsaiTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\AICALC.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_ENCOUNT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.EncounterTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\ENCOUNT.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_EXIST()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.ExistTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\EXIST.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_ITEM()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.ItemTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\ITEM.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_NAME()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.NameTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\NAME.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_PERSONA()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.PersonaTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\PERSONA.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_PLAYER()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.PlayerTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\PLAYER.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_SKILL()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.SkillTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\SKILL.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_TALKINFO()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.TalkInfoTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\TALKINFO.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_UNIT()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.UnitTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\UNIT.TBL", Endianness.BigEndian);
        }

        [TestMethod()]
        public void DeserializeAndSerialize_BinariesShouldBeIdenticial_Persona5_VISUAL()
        {
            DeserializeAndSerialize_BinariesShouldBeIdentical_Base<Persona5.VisualTable>(
                @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\VISUAL.TBL", Endianness.BigEndian);
        }
    }
}