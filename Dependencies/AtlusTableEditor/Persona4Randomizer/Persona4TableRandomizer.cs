using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AtlusTableLib.Persona4;
using AtlusTableLib.Serialization;

namespace AtlusRandomizer
{
    public class Persona4TableRandomizer : TableRandomizer
    {
        public static void Randomize(string tableDirectoryPath, List<string> options, bool isP4G, bool bossRush = false)
        {
            foreach (var path in Directory.EnumerateFiles(tableDirectoryPath, "*.TBL"))
            {
                switch (Path.GetFileNameWithoutExtension(path).ToUpperInvariant())
                {
                    case "ENCOUNT":
                        if (options.Any(x => x.Equals("ENCOUNT")))
                        {
                            if (bossRush)
                                RandomizeEncounterTableBossRush(path, isP4G);
                            else
                                RandomizeEncounterTable(path, isP4G);
                        }
                        break;

                    case "MODEL":
                        if (options.Any(x => x.Equals("MODEL")))
                            RandomizeModelTable(path);
                        break;

                    case "MSG":
                        if (options.Any(x => x.Equals("MSG")))
                            RandomizeMessageTable(path);
                        break;

                    case "PERSONA":
                        if (options.Any(x => x.Equals("PERSONA")))
                            RandomizePersonaTable(path);
                        break;

                    case "SKILL":
                        if (options.Any(x => x.Equals("SKILL")))
                        {
                            if (isP4G)
                                RandomizeSkillTableP4G(path);
                            else
                                RandomizeSkillTable(path);
                        }
                        break;

                    case "UNIT":
                        if (options.Any(x => x.Equals("UNIT")))
                            RandomizeUnitTable(path);
                        break;
                }
            }
        }

        private static void RandomizeUnitTable(string tablePath)
        {
            var table = TableSerializer.Deserialize<UnitTable>(tablePath);
            var values = GetTableDistinctValues(table);

            var unitValues = (Dictionary<string, List<object>>)values[nameof(table.Units)][0];
            for (int i = 0; i < table.Units.Length; i++)
            {
                ref var unit = ref table.Units[i];

                unit.ArcanaId = GetRandom<byte>(unitValues[nameof(unit.ArcanaId)]);
                unit.Level = GetRandom<byte>(unitValues[nameof(unit.Level)]);
                unit.Strength = GetRandom<byte>(unitValues[nameof(unit.Strength)]);
                unit.Magic = GetRandom<byte>(unitValues[nameof(unit.Magic)]);
                unit.Endurance = GetRandom<byte>(unitValues[nameof(unit.Endurance)]);
                unit.Agility = GetRandom<byte>(unitValues[nameof(unit.Agility)]);
                unit.Luck = GetRandom<byte>(unitValues[nameof(unit.Luck)]);
                for (int j = 0; j < unit.SkillIDs.Length; j++)
                {
                    unit.SkillIDs[j] = (ushort)Random.Next(0, Constants.SKILL_COUNT_REAL - 1);
                }

                unit.ExpReward = GetRandom<ushort>(unitValues[nameof(unit.ExpReward)]);
                unit.YenReward = GetRandom<ushort>(unitValues[nameof(unit.YenReward)]);
                unit.AttackDamage = GetRandom<ushort>(unitValues[nameof(unit.AttackDamage)]);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeSkillTable(string tablePath)
        {
            var table = TableSerializer.Deserialize<SkillTable>(tablePath);
            var values = GetTableDistinctValues(table);

            var skillTypeValues = values[nameof(table.SkillElementTypes)];
            for (int i = 0; i < table.SkillElementTypes.Length; i++)
            {
                table.SkillElementTypes[i] = GetRandom<SkillElementType>(skillTypeValues);
            }

            var skillValues = (Dictionary<string, List<object>>)values[nameof(table.Skills)][0];
            for (var i = 0; i < table.Skills.Length; i++)
            {
                ref var skill = ref table.Skills[i];

                skill.DrainType = GetRandom<SkillUsageDrainType>(skillValues[nameof(skill.DrainType)]);
                skill.Cost = GetRandom<ushort>(skillValues[nameof(skill.Cost)]);
                skill.TargetSelectionMode = GetRandom<SkillTargetSelectionMode>(skillValues[nameof(skill.TargetSelectionMode)]);
                skill.TargetFilterFlags = GetRandom<SkillTargetFilterFlags>(skillValues[nameof(skill.TargetFilterFlags)]);
                skill.HpPowerType = GetRandom<SkillPowerType>(skillValues[nameof(skill.HpPowerType)]);
                skill.HpPower = GetRandom<ushort>(skillValues[nameof(skill.HpPower)]);
                skill.SpPowerType = GetRandom<SkillPowerType>(skillValues[nameof(skill.SpPowerType)]);
                skill.SpPower = GetRandom<ushort>(skillValues[nameof(skill.SpPower)]);
                skill.ChanceType = GetRandom<byte>(skillValues[nameof(skill.ChanceType)]);
                skill.Chance = GetRandom<ushort>(skillValues[nameof(skill.Chance)]);
                skill.AilmentFlags = GetRandom<SkillAilmentFlags>(skillValues[nameof(skill.AilmentFlags)]);
                skill.AdditionalEffectFlags = GetRandom<SkillAdditionalEffectFlags>(skillValues[nameof(skill.AdditionalEffectFlags)]);
                skill.StatusEffectFlags = GetRandom<SkillStatusEffectFlags>(skillValues[nameof(skill.StatusEffectFlags)]);
                skill.CriticalChance = GetRandom<byte>(skillValues[nameof(skill.CriticalChance)]);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeSkillTableP4G(string tablePath)
        {
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona4Golden.SkillTable>(tablePath);
            var values = GetTableDistinctValues(table);

            var skillTypeValues = values[nameof(table.SkillElementTypes)];
            for (int i = 0; i < table.SkillElementTypes.Length; i++)
            {
                table.SkillElementTypes[i] = GetRandom<SkillElementType>(skillTypeValues);
            }

            var skillValues = (Dictionary<string, List<object>>)values[nameof(table.Skills)][0];
            for (var i = 0; i < table.Skills.Length; i++)
            {
                ref var skill = ref table.Skills[i];

                skill.DrainType = GetRandom<SkillUsageDrainType>(skillValues[nameof(skill.DrainType)]);
                skill.Cost = GetRandom<ushort>(skillValues[nameof(skill.Cost)]);
                skill.TargetSelectionMode = GetRandom<SkillTargetSelectionMode>(skillValues[nameof(skill.TargetSelectionMode)]);
                skill.TargetFilterFlags = GetRandom<SkillTargetFilterFlags>(skillValues[nameof(skill.TargetFilterFlags)]);
                skill.HpPowerType = GetRandom<SkillPowerType>(skillValues[nameof(skill.HpPowerType)]);
                skill.HpPower = GetRandom<ushort>(skillValues[nameof(skill.HpPower)]);
                skill.SpPowerType = GetRandom<SkillPowerType>(skillValues[nameof(skill.SpPowerType)]);
                skill.SpPower = GetRandom<ushort>(skillValues[nameof(skill.SpPower)]);
                skill.ChanceType = GetRandom<byte>(skillValues[nameof(skill.ChanceType)]);
                skill.Chance = GetRandom<ushort>(skillValues[nameof(skill.Chance)]);
                skill.AilmentFlags = GetRandom<SkillAilmentFlags>(skillValues[nameof(skill.AilmentFlags)]);
                skill.AdditionalEffectFlags = GetRandom<SkillAdditionalEffectFlags>(skillValues[nameof(skill.AdditionalEffectFlags)]);
                skill.StatusEffectFlags = GetRandom<SkillStatusEffectFlags>(skillValues[nameof(skill.StatusEffectFlags)]);
                skill.CriticalChance = GetRandom<byte>(skillValues[nameof(skill.CriticalChance)]);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }


        private static void RandomizePersonaTable(string tablePath)
        {
            var table = TableSerializer.Deserialize<PersonaTable>(tablePath);
            var values = GetTableDistinctValues(table);

            var personaInfoValues = (Dictionary<string, List<object>>)values[nameof(table.PersonaInfo)][0];
            for (var i = 0; i < table.PersonaInfo.Length; i++)
            {
                ref var stats = ref table.PersonaInfo[i];
                stats.Flags1 = GetRandom<byte>(personaInfoValues[nameof(stats.Flags1)]);
                stats.ArcanaIndex = GetRandom<byte>(personaInfoValues[nameof(stats.ArcanaIndex)]);
                stats.Level = GetRandom<byte>(personaInfoValues[nameof(stats.Level)]);
                stats.Strength = GetRandom<byte>(personaInfoValues[nameof(stats.Strength)]);
                stats.Magic = GetRandom<byte>(personaInfoValues[nameof(stats.Magic)]);
                stats.Endurance = GetRandom<byte>(personaInfoValues[nameof(stats.Endurance)]);
                stats.Agility = GetRandom<byte>(personaInfoValues[nameof(stats.Agility)]);
                stats.Luck = GetRandom<byte>(personaInfoValues[nameof(stats.Luck)]);
                stats.Flags2 = GetRandom<byte>(personaInfoValues[nameof(stats.Flags2)]);
                stats.Flags3 = GetRandom<byte>(personaInfoValues[nameof(stats.Flags3)]);
                stats.FusionMessageIndex = GetRandom<byte>(personaInfoValues[nameof(stats.FusionMessageIndex)]);
            }

            var personaSkillSetValues = (Dictionary<string, List<object>>)values[nameof(table.PersonaSkillSets)][0];
            for (int i = 0; i < table.PersonaSkillSets.Length; i++)
            {
                ref var skillSet = ref table.PersonaSkillSets[i];

                for (int j = 0; j < skillSet.Skills.Length; j++)
                {
                    skillSet.Skills[j].SkillId = (ushort)Random.Next(0, Constants.SKILL_COUNT_REAL - 1);
                }
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeModelTable(string tablePath)
        {
            var table = TableSerializer.Deserialize<ModelTable>(tablePath);

            for (var i = 0; i < table.PartyModelInfo.Length; i++)
            {
                ref var modelInfo = ref table.PartyModelInfo[i];
                modelInfo.Scale = (ushort)Random.Next(0, 400);
                modelInfo.AttackRange = (ushort)Random.Next(0, 10);
            }

            for (var i = 0; i < table.UnitModelInfo.Length; i++)
            {
                ref var modelInfo = ref table.UnitModelInfo[i];
                modelInfo.Scale = (ushort)Random.Next(0, 400);
            }

            for (var i = 0; i < table.PersonaModelInfo.Length; i++)
            {
                ref var modelInfo = ref table.PersonaModelInfo[i];
                modelInfo.Scale = (ushort)Random.Next(0, 200);
                modelInfo.AttackRange = (ushort)Random.Next(0, 10);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeEncounterTable(string tablePath, bool isP4G)
        {
            var table = TableSerializer.Deserialize<EncounterTable>(tablePath);

            var values = GetTableDistinctValues(table);
            var fieldAndRoomIds = p4fields;
            if (isP4G)
                fieldAndRoomIds = p4gfields;

            var encounterValues = (Dictionary<string, List<object>>)values[nameof(table.Encounters)][0];
            for (var i = 0; i < table.Encounters.Length; i++)
            {
                ref var e = ref table.Encounters[i];
                e.EncounterType = 1;
                e.Field02 = 0;
                e.Field04 = 0;
                e.Field06 = 0;

                for (int j = 0; j < Random.Next(2, 5); j++)
                {
                    e.UnitIds[j] = (ushort)Random.Next(1, Constants.UNIT_COUNT - 1);
                }

                var fieldAndRoomTuple = GetRandom<Tuple<ushort, ushort>>(fieldAndRoomIds);
                e.FieldId = fieldAndRoomTuple.Item1;
                e.RoomId = fieldAndRoomTuple.Item2;
                e.MusicId = (ushort)Random.Next(0, 11);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeEncounterTableBossRush(string tablePath, bool isP4G)
        {
            var table = TableSerializer.Deserialize<EncounterTable>(tablePath);

            var values = GetTableDistinctValues(table);
            var fieldAndRoomIds = p4fields;
            if (isP4G)
                fieldAndRoomIds = p4gfields;

            var encounterValues = (Dictionary<string, List<object>>)values[nameof(table.Encounters)][0];
            for (var i = 0; i < table.Encounters.Length; i++)
            {
                ref var e = ref table.Encounters[i];
                e.EncounterType = 1;
                e.Field02 = 0;
                e.Field04 = 0;
                e.Field06 = 0;

                for (int j = 0; j < Random.Next(1, 5); j++)
                {
                    e.UnitIds[j] = (ushort)Random.Next(0x100, 0x113);
                }

                var fieldAndRoomTuple = GetRandom<Tuple<ushort, ushort>>(fieldAndRoomIds);
                e.FieldId = fieldAndRoomTuple.Item1;
                e.RoomId = fieldAndRoomTuple.Item2;
                e.MusicId = (ushort)Random.Next(0, 11);
            }

            TableSerializer.Serialize(table, tablePath + ".bossrush.randomized");
        }

        private static void RandomizeMessageTable(string tablePath)
        {
            string[] translated;
            var table = TableSerializer.Deserialize<MessageTable>(tablePath);
            BadTranslator.Translate(table.ArcanaNames, out translated);
            translated = table.ArcanaNames;
            BadTranslator.Translate(table.PersonaNames, out translated);
            translated = table.PersonaNames;
            BadTranslator.Translate(table.SkillNames, out translated);
            translated = table.SkillNames;
            BadTranslator.Translate(table.UnitNames, out translated);
            translated = table.UnitNames;
            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static List<Tuple<ushort, ushort>> GetFieldAndRoomIds(string fieldpath)
        {
            var fieldAndRoomIds = new List<Tuple<ushort, ushort>>();

            foreach (string file in Directory.EnumerateFiles(fieldpath, "*.p01"))
            {
                string fileName = Path.GetFileName(file); // F001_001
                ushort fieldId = ushort.Parse(fileName.Substring(1, 3)); // F<001>_001
                ushort roomId = ushort.Parse(fileName.Substring(5, 3)); // F001_<001>
                fieldAndRoomIds.Add(new Tuple<ushort, ushort>(fieldId, roomId));
            }

            return fieldAndRoomIds;
        }

        public static List<Tuple<ushort, ushort>> p4gfields = new List<Tuple<ushort, ushort>>()
        {
            new Tuple<ushort, ushort>(001, 001),
            new Tuple<ushort, ushort>(004, 001),
            new Tuple<ushort, ushort>(004, 002),
            new Tuple<ushort, ushort>(004, 003),
            new Tuple<ushort, ushort>(006, 001),
            new Tuple<ushort, ushort>(006, 002),
            new Tuple<ushort, ushort>(006, 003),
            new Tuple<ushort, ushort>(006, 004),
            new Tuple<ushort, ushort>(006, 005),
            new Tuple<ushort, ushort>(006, 006),
            new Tuple<ushort, ushort>(006, 007),
            new Tuple<ushort, ushort>(006, 008),
            new Tuple<ushort, ushort>(006, 009),
            new Tuple<ushort, ushort>(006, 010),
            new Tuple<ushort, ushort>(006, 011),
            new Tuple<ushort, ushort>(006, 012),
            new Tuple<ushort, ushort>(006, 013),
            new Tuple<ushort, ushort>(006, 014),
            new Tuple<ushort, ushort>(006, 015),
            new Tuple<ushort, ushort>(006, 016),
            new Tuple<ushort, ushort>(006, 017),
            new Tuple<ushort, ushort>(007, 001),
            new Tuple<ushort, ushort>(007, 002),
            new Tuple<ushort, ushort>(007, 003),
            new Tuple<ushort, ushort>(008, 001),
            new Tuple<ushort, ushort>(008, 002),
            new Tuple<ushort, ushort>(008, 003),
            new Tuple<ushort, ushort>(008, 004),
            new Tuple<ushort, ushort>(008, 005),
            new Tuple<ushort, ushort>(008, 006),
            new Tuple<ushort, ushort>(008, 007),
            new Tuple<ushort, ushort>(008, 008),
            new Tuple<ushort, ushort>(008, 009),
            new Tuple<ushort, ushort>(008, 010),
            new Tuple<ushort, ushort>(008, 011),
            new Tuple<ushort, ushort>(008, 015),
            new Tuple<ushort, ushort>(009, 001),
            new Tuple<ushort, ushort>(009, 002),
            new Tuple<ushort, ushort>(009, 003),
            new Tuple<ushort, ushort>(009, 004),
            new Tuple<ushort, ushort>(010, 001),
            new Tuple<ushort, ushort>(010, 002),
            new Tuple<ushort, ushort>(010, 003),
            new Tuple<ushort, ushort>(010, 004),
            new Tuple<ushort, ushort>(011, 001),
            new Tuple<ushort, ushort>(011, 002),
            new Tuple<ushort, ushort>(012, 002),
            new Tuple<ushort, ushort>(012, 003),
            new Tuple<ushort, ushort>(012, 004),
            new Tuple<ushort, ushort>(013, 001),
            new Tuple<ushort, ushort>(013, 006),
            new Tuple<ushort, ushort>(013, 008),
            new Tuple<ushort, ushort>(014, 001),
            new Tuple<ushort, ushort>(014, 002),
            new Tuple<ushort, ushort>(015, 001),
            new Tuple<ushort, ushort>(015, 002),
            new Tuple<ushort, ushort>(015, 003),
            new Tuple<ushort, ushort>(016, 001),
            new Tuple<ushort, ushort>(016, 002),
            new Tuple<ushort, ushort>(016, 003),
            new Tuple<ushort, ushort>(016, 004),
            new Tuple<ushort, ushort>(016, 005),
            new Tuple<ushort, ushort>(016, 006),
            new Tuple<ushort, ushort>(017, 001),
            new Tuple<ushort, ushort>(017, 002),
            new Tuple<ushort, ushort>(017, 003),
            new Tuple<ushort, ushort>(017, 004),
            new Tuple<ushort, ushort>(017, 007),
            new Tuple<ushort, ushort>(017, 008),
            new Tuple<ushort, ushort>(017, 009),
            new Tuple<ushort, ushort>(018, 001),
            new Tuple<ushort, ushort>(018, 002),
            new Tuple<ushort, ushort>(018, 003),
            new Tuple<ushort, ushort>(018, 004),
            new Tuple<ushort, ushort>(020, 001),
            new Tuple<ushort, ushort>(021, 001),
            new Tuple<ushort, ushort>(021, 002),
            new Tuple<ushort, ushort>(022, 001),
            new Tuple<ushort, ushort>(022, 002),
            new Tuple<ushort, ushort>(023, 001),
            new Tuple<ushort, ushort>(023, 002),
            new Tuple<ushort, ushort>(023, 003),
            new Tuple<ushort, ushort>(024, 001),
            new Tuple<ushort, ushort>(024, 002),
            new Tuple<ushort, ushort>(025, 001),
            new Tuple<ushort, ushort>(025, 002),
            new Tuple<ushort, ushort>(026, 001),
            new Tuple<ushort, ushort>(026, 002),
            new Tuple<ushort, ushort>(027, 001),
            new Tuple<ushort, ushort>(027, 002),
            new Tuple<ushort, ushort>(028, 001),
            new Tuple<ushort, ushort>(028, 002),
            new Tuple<ushort, ushort>(029, 001),
            new Tuple<ushort, ushort>(029, 002),
            new Tuple<ushort, ushort>(030, 001),
            new Tuple<ushort, ushort>(030, 002),
            new Tuple<ushort, ushort>(031, 001),
            new Tuple<ushort, ushort>(031, 002),
            new Tuple<ushort, ushort>(040, 000),
            new Tuple<ushort, ushort>(041, 000),
            new Tuple<ushort, ushort>(042, 000),
            new Tuple<ushort, ushort>(043, 000),
            new Tuple<ushort, ushort>(044, 000),
            new Tuple<ushort, ushort>(045, 000),
            new Tuple<ushort, ushort>(046, 000),
            new Tuple<ushort, ushort>(047, 000),
            new Tuple<ushort, ushort>(048, 000),
            new Tuple<ushort, ushort>(049, 000),
            new Tuple<ushort, ushort>(060, 001),
            new Tuple<ushort, ushort>(061, 001),
            new Tuple<ushort, ushort>(061, 002),
            new Tuple<ushort, ushort>(061, 003),
            new Tuple<ushort, ushort>(062, 001),
            new Tuple<ushort, ushort>(062, 002),
            new Tuple<ushort, ushort>(062, 003),
            new Tuple<ushort, ushort>(063, 001),
            new Tuple<ushort, ushort>(063, 002),
            new Tuple<ushort, ushort>(064, 001),
            new Tuple<ushort, ushort>(064, 002),
            new Tuple<ushort, ushort>(064, 003),
            new Tuple<ushort, ushort>(065, 001),
            new Tuple<ushort, ushort>(065, 002),
            new Tuple<ushort, ushort>(066, 001),
            new Tuple<ushort, ushort>(066, 002),
            new Tuple<ushort, ushort>(066, 003),
            new Tuple<ushort, ushort>(067, 001),
            new Tuple<ushort, ushort>(067, 002),
            new Tuple<ushort, ushort>(068, 001),
            new Tuple<ushort, ushort>(069, 001),
            new Tuple<ushort, ushort>(069, 002),
            new Tuple<ushort, ushort>(069, 003),
            new Tuple<ushort, ushort>(069, 004),
            new Tuple<ushort, ushort>(100, 001),
            new Tuple<ushort, ushort>(100, 002),
            new Tuple<ushort, ushort>(100, 003),
            new Tuple<ushort, ushort>(222, 001),
            new Tuple<ushort, ushort>(222, 002),
            new Tuple<ushort, ushort>(222, 003),
            new Tuple<ushort, ushort>(240, 001),
            new Tuple<ushort, ushort>(240, 002),
            new Tuple<ushort, ushort>(240, 003),
            new Tuple<ushort, ushort>(241, 001),
            new Tuple<ushort, ushort>(241, 002),
            new Tuple<ushort, ushort>(242, 001),
            new Tuple<ushort, ushort>(242, 002),
            new Tuple<ushort, ushort>(242, 003),
            new Tuple<ushort, ushort>(243, 001),
            new Tuple<ushort, ushort>(243, 002),
            new Tuple<ushort, ushort>(244, 001),
            new Tuple<ushort, ushort>(244, 002),
            new Tuple<ushort, ushort>(244, 003),
            new Tuple<ushort, ushort>(245, 001),
            new Tuple<ushort, ushort>(245, 002),
            new Tuple<ushort, ushort>(246, 001),
            new Tuple<ushort, ushort>(246, 002),
            new Tuple<ushort, ushort>(246, 003),
            new Tuple<ushort, ushort>(247, 001),
            new Tuple<ushort, ushort>(247, 002),
            new Tuple<ushort, ushort>(248, 001),
            new Tuple<ushort, ushort>(248, 002),
            new Tuple<ushort, ushort>(248, 003)
        };

        public static List<Tuple<ushort, ushort>> p4fields = new List<Tuple<ushort, ushort>>()
        {
            new Tuple<ushort, ushort>(001, 001),
            new Tuple<ushort, ushort>(004, 001),
            new Tuple<ushort, ushort>(004, 002),
            new Tuple<ushort, ushort>(004, 003),
            new Tuple<ushort, ushort>(006, 001),
            new Tuple<ushort, ushort>(006, 002),
            new Tuple<ushort, ushort>(006, 003),
            new Tuple<ushort, ushort>(006, 004),
            new Tuple<ushort, ushort>(006, 005),
            new Tuple<ushort, ushort>(006, 006),
            new Tuple<ushort, ushort>(006, 007),
            new Tuple<ushort, ushort>(006, 008),
            new Tuple<ushort, ushort>(006, 009),
            new Tuple<ushort, ushort>(006, 010),
            new Tuple<ushort, ushort>(006, 011),
            new Tuple<ushort, ushort>(006, 012),
            new Tuple<ushort, ushort>(006, 013),
            new Tuple<ushort, ushort>(006, 014),
            new Tuple<ushort, ushort>(006, 015),
            new Tuple<ushort, ushort>(006, 016),
            new Tuple<ushort, ushort>(006, 017),
            new Tuple<ushort, ushort>(007, 001),
            new Tuple<ushort, ushort>(007, 002),
            new Tuple<ushort, ushort>(007, 003),
            new Tuple<ushort, ushort>(008, 001),
            new Tuple<ushort, ushort>(008, 002),
            new Tuple<ushort, ushort>(008, 003),
            new Tuple<ushort, ushort>(008, 004),
            new Tuple<ushort, ushort>(008, 005),
            new Tuple<ushort, ushort>(008, 006),
            new Tuple<ushort, ushort>(008, 007),
            new Tuple<ushort, ushort>(008, 008),
            new Tuple<ushort, ushort>(008, 009),
            new Tuple<ushort, ushort>(008, 010),
            new Tuple<ushort, ushort>(009, 001),
            new Tuple<ushort, ushort>(009, 002),
            new Tuple<ushort, ushort>(009, 003),
            new Tuple<ushort, ushort>(009, 004),
            new Tuple<ushort, ushort>(010, 001),
            new Tuple<ushort, ushort>(010, 002),
            new Tuple<ushort, ushort>(010, 003),
            new Tuple<ushort, ushort>(010, 004),
            new Tuple<ushort, ushort>(011, 001),
            new Tuple<ushort, ushort>(011, 002),
            new Tuple<ushort, ushort>(012, 002),
            new Tuple<ushort, ushort>(012, 003),
            new Tuple<ushort, ushort>(012, 004),
            new Tuple<ushort, ushort>(013, 001),
            new Tuple<ushort, ushort>(013, 006),
            new Tuple<ushort, ushort>(013, 007),
            new Tuple<ushort, ushort>(013, 008),
            new Tuple<ushort, ushort>(014, 001),
            new Tuple<ushort, ushort>(014, 002),
            new Tuple<ushort, ushort>(015, 001),
            new Tuple<ushort, ushort>(015, 002),
            new Tuple<ushort, ushort>(015, 003),
            new Tuple<ushort, ushort>(016, 001),
            new Tuple<ushort, ushort>(016, 002),
            new Tuple<ushort, ushort>(016, 003),
            new Tuple<ushort, ushort>(016, 004),
            new Tuple<ushort, ushort>(016, 005),
            new Tuple<ushort, ushort>(017, 001),
            new Tuple<ushort, ushort>(017, 002),
            new Tuple<ushort, ushort>(017, 003),
            new Tuple<ushort, ushort>(020, 001),
            new Tuple<ushort, ushort>(021, 001),
            new Tuple<ushort, ushort>(021, 002),
            new Tuple<ushort, ushort>(022, 001),
            new Tuple<ushort, ushort>(022, 002),
            new Tuple<ushort, ushort>(023, 001),
            new Tuple<ushort, ushort>(023, 002),
            new Tuple<ushort, ushort>(023, 003),
            new Tuple<ushort, ushort>(024, 001),
            new Tuple<ushort, ushort>(024, 002),
            new Tuple<ushort, ushort>(025, 001),
            new Tuple<ushort, ushort>(025, 002),
            new Tuple<ushort, ushort>(026, 001),
            new Tuple<ushort, ushort>(026, 002),
            new Tuple<ushort, ushort>(027, 001),
            new Tuple<ushort, ushort>(027, 002),
            new Tuple<ushort, ushort>(028, 001),
            new Tuple<ushort, ushort>(028, 002),
            new Tuple<ushort, ushort>(029, 001),
            new Tuple<ushort, ushort>(029, 002),
            new Tuple<ushort, ushort>(030, 001),
            new Tuple<ushort, ushort>(030, 002),
            new Tuple<ushort, ushort>(040, 000),
            new Tuple<ushort, ushort>(040, 001),
            new Tuple<ushort, ushort>(040, 002),
            new Tuple<ushort, ushort>(041, 000),
            new Tuple<ushort, ushort>(041, 001),
            new Tuple<ushort, ushort>(041, 002),
            new Tuple<ushort, ushort>(042, 000),
            new Tuple<ushort, ushort>(042, 001),
            new Tuple<ushort, ushort>(042, 002),
            new Tuple<ushort, ushort>(043, 000),
            new Tuple<ushort, ushort>(043, 001),
            new Tuple<ushort, ushort>(043, 002),
            new Tuple<ushort, ushort>(044, 000),
            new Tuple<ushort, ushort>(044, 001),
            new Tuple<ushort, ushort>(044, 002),
            new Tuple<ushort, ushort>(045, 000),
            new Tuple<ushort, ushort>(045, 001),
            new Tuple<ushort, ushort>(045, 002),
            new Tuple<ushort, ushort>(046, 000),
            new Tuple<ushort, ushort>(046, 001),
            new Tuple<ushort, ushort>(046, 002),
            new Tuple<ushort, ushort>(047, 000),
            new Tuple<ushort, ushort>(047, 001),
            new Tuple<ushort, ushort>(047, 002),
            new Tuple<ushort, ushort>(048, 000),
            new Tuple<ushort, ushort>(048, 001),
            new Tuple<ushort, ushort>(048, 002),
            new Tuple<ushort, ushort>(060, 001),
            new Tuple<ushort, ushort>(061, 001),
            new Tuple<ushort, ushort>(061, 002),
            new Tuple<ushort, ushort>(061, 003),
            new Tuple<ushort, ushort>(062, 001),
            new Tuple<ushort, ushort>(062, 002),
            new Tuple<ushort, ushort>(062, 003),
            new Tuple<ushort, ushort>(063, 001),
            new Tuple<ushort, ushort>(063, 002),
            new Tuple<ushort, ushort>(064, 001),
            new Tuple<ushort, ushort>(064, 002),
            new Tuple<ushort, ushort>(064, 003),
            new Tuple<ushort, ushort>(065, 001),
            new Tuple<ushort, ushort>(065, 002),
            new Tuple<ushort, ushort>(066, 001),
            new Tuple<ushort, ushort>(066, 002),
            new Tuple<ushort, ushort>(066, 003),
            new Tuple<ushort, ushort>(067, 001),
            new Tuple<ushort, ushort>(067, 002),
            new Tuple<ushort, ushort>(067, 003),
            new Tuple<ushort, ushort>(068, 001),
            new Tuple<ushort, ushort>(100, 001),
            new Tuple<ushort, ushort>(100, 002),
            new Tuple<ushort, ushort>(100, 003),
            new Tuple<ushort, ushort>(222, 001),
            new Tuple<ushort, ushort>(222, 002),
            new Tuple<ushort, ushort>(222, 003),
            new Tuple<ushort, ushort>(240, 001),
            new Tuple<ushort, ushort>(240, 002),
            new Tuple<ushort, ushort>(240, 003),
            new Tuple<ushort, ushort>(241, 001),
            new Tuple<ushort, ushort>(241, 002),
            new Tuple<ushort, ushort>(242, 001),
            new Tuple<ushort, ushort>(242, 002),
            new Tuple<ushort, ushort>(242, 003),
            new Tuple<ushort, ushort>(243, 001),
            new Tuple<ushort, ushort>(243, 002),
            new Tuple<ushort, ushort>(244, 001),
            new Tuple<ushort, ushort>(244, 002),
            new Tuple<ushort, ushort>(244, 003),
            new Tuple<ushort, ushort>(245, 001),
            new Tuple<ushort, ushort>(245, 002),
            new Tuple<ushort, ushort>(246, 001),
            new Tuple<ushort, ushort>(246, 002),
            new Tuple<ushort, ushort>(246, 003),
            new Tuple<ushort, ushort>(247, 001),
            new Tuple<ushort, ushort>(247, 002)
        };
    }
}
