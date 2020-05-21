using System;
using System.Collections.Generic;
using System.IO;
using AtlusScriptLib;
using AtlusTableLib.Serialization;
using AtlusTableLib.Persona3FES;

namespace AtlusRandomizer
{
    public class Persona3FesTableRandomizer : TableRandomizer
    {
        public static void Randomize(string tableDirectoryPath, bool[] options, bool bossrush = false)
        {
            foreach (var path in Directory.EnumerateFiles(tableDirectoryPath, "*.TBL"))
            {
                switch (Path.GetFileNameWithoutExtension(path).ToUpperInvariant())
                {
                    case "AICALC":
                        if (options[0])
                            RandomizeAICalculationTable(path);
                        break;

                    case "AICALC_F":
                        if (options[1])
                            RandomizeAICalculationTableFES(path);
                        break;

                    case "ENCOUNT":
                        if (options[2])
                        {
                            if (bossrush)
                                RandomizeEncounterTableBossRush(path, path);
                            else
                                RandomizeEncounterTable(path, path);
                        }
                        break;

                    case "ENCOUNT_F":
                        if (options[3])
                        {
                            if (bossrush)
                                RandomizeEncounterTableBossRushFES(path, path);
                            else
                                RandomizeEncounterTableFES(path, path);
                        }
                        break;

                    case "MODEL":
                        if (options[4])
                            RandomizeModelTable(path);
                        break;

                    case "MSG":
                        if (options[5])
                            RandomizeMessageTable(path);
                        break;

                    case "PERSONA":
                        if (options[6])
                            RandomizePersonaTable(path);
                        break;

                    case "PERSONA_F":
                        if (options[7])
                            RandomizePersonaTableFES(path);
                        break;

                    case "SKILL":
                        if (options[8])
                            RandomizeSkillTable(path);
                        break;

                    case "SKILL_F":
                        if (options[9])
                            RandomizeSkillTableFES(path);
                        break;

                    case "UNIT":
                        if (options[10])
                            RandomizeUnitTable(path);
                        break;

                    case "UNIT_F":
                        if (options[11])
                            RandomizeUnitTableFES(path);
                        break;
                }
            }
        }

        private static void RandomizeAICalculationTable(string tablePath)
        {
            var table = TableSerializer.Deserialize<AICalculationTable>(tablePath);
            table.PlayerAIScript = ScriptRandomizer.RandomizeFlowScript(table.PlayerAIScript);
            table.BossAIScript = ScriptRandomizer.RandomizeFlowScript(table.BossAIScript);

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeAICalculationTableFES(string tablePath)
        {
            var table = TableSerializer.Deserialize<AICalculationTableF>(tablePath);
            table.PlayerAIScript = ScriptRandomizer.RandomizeFlowScript(table.PlayerAIScript);
            table.BossAIScript = ScriptRandomizer.RandomizeFlowScript(table.BossAIScript);

            TableSerializer.Serialize(table, tablePath + "_Randomized");
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
                    unit.SkillIDs[j] = (ushort)Random.Next(0, AtlusTableLib.Persona4.Constants.SKILL_COUNT_REAL - 1);
                }

                unit.ExpReward = GetRandom<ushort>(unitValues[nameof(unit.ExpReward)]);
                unit.YenReward = GetRandom<ushort>(unitValues[nameof(unit.YenReward)]);
                unit.AttackDamage = GetRandom<ushort>(unitValues[nameof(unit.AttackDamage)]);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeUnitTableFES(string tablePath)
        {
            var table = TableSerializer.Deserialize<UnitTableF>(tablePath);
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
                    unit.SkillIDs[j] = (ushort)Random.Next(0, AtlusTableLib.Persona4.Constants.SKILL_COUNT_REAL - 1);
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

        private static void RandomizeSkillTableFES(string tablePath)
        {
            var table = TableSerializer.Deserialize<SkillTableF>(tablePath);
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

            var personaStatValues = (Dictionary<string, List<object>>)values[nameof(table.PersonaStats)][0];
            for (var i = 0; i < table.PersonaStats.Length; i++)
            {
                ref var stats = ref table.PersonaStats[i];
                stats.Flags1 = GetRandom<ushort>(personaStatValues[nameof(stats.Flags1)]);
                stats.ArcanaIndex = GetRandom<byte>(personaStatValues[nameof(stats.ArcanaIndex)]);
                stats.Level = GetRandom<byte>(personaStatValues[nameof(stats.Level)]);
                stats.Strength = GetRandom<byte>(personaStatValues[nameof(stats.Strength)]);
                stats.Magic = GetRandom<byte>(personaStatValues[nameof(stats.Magic)]);
                stats.Endurance = GetRandom<byte>(personaStatValues[nameof(stats.Endurance)]);
                stats.Agility = GetRandom<byte>(personaStatValues[nameof(stats.Agility)]);
                stats.Luck = GetRandom<byte>(personaStatValues[nameof(stats.Luck)]);
                stats.Flags2 = GetRandom<ushort>(personaStatValues[nameof(stats.Flags2)]);
                stats.Flags3 = GetRandom<ushort>(personaStatValues[nameof(stats.Flags3)]);
                stats.FusionMessageIndex = GetRandom<byte>(personaStatValues[nameof(stats.FusionMessageIndex)]);
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

            TableSerializer.Serialize(table, tablePath + ".randomized");
        }

        private static void RandomizePersonaTableFES(string tablePath)
        {
            var table = TableSerializer.Deserialize<PersonaTableF>(tablePath);
            var values = GetTableDistinctValues(table);

            var personaStatValues = (Dictionary<string, List<object>>)values[nameof(table.PersonaStats)][0];
            for (var i = 0; i < table.PersonaStats.Length; i++)
            {
                ref var stats = ref table.PersonaStats[i];
                stats.Flags1 = GetRandom<ushort>(personaStatValues[nameof(stats.Flags1)]);
                stats.ArcanaIndex = GetRandom<byte>(personaStatValues[nameof(stats.ArcanaIndex)]);
                stats.Level = GetRandom<byte>(personaStatValues[nameof(stats.Level)]);
                stats.Strength = GetRandom<byte>(personaStatValues[nameof(stats.Strength)]);
                stats.Magic = GetRandom<byte>(personaStatValues[nameof(stats.Magic)]);
                stats.Endurance = GetRandom<byte>(personaStatValues[nameof(stats.Endurance)]);
                stats.Agility = GetRandom<byte>(personaStatValues[nameof(stats.Agility)]);
                stats.Luck = GetRandom<byte>(personaStatValues[nameof(stats.Luck)]);
                stats.Flags2 = GetRandom<ushort>(personaStatValues[nameof(stats.Flags2)]);
                stats.Flags3 = GetRandom<ushort>(personaStatValues[nameof(stats.Flags3)]);
                stats.FusionMessageIndex = GetRandom<byte>(personaStatValues[nameof(stats.FusionMessageIndex)]);
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
                //modelInfo.AttackRange = (ushort)Random.Next(0, 10);
            }

            for (var i = 0; i < table.Party2ModelInfo.Length; i++)
            {
                ref var modelInfo = ref table.Party2ModelInfo[i];
                modelInfo.Scale = (ushort)Random.Next(0, 400);
                //modelInfo.AttackRange = (ushort)Random.Next(0, 10);
            }

            for (var i = 0; i < table.UnitModelInfo.Length; i++)
            {
                ref var modelInfo = ref table.UnitModelInfo[i];
                modelInfo.Scale = (ushort)Random.Next(0, 400);
            }

            for (var i = 0; i < table.PersonaModelInfo.Length; i++)
            {
                ref var modelInfo = ref table.PersonaModelInfo[i];
                //modelInfo.Scale = (ushort)Random.Next(0, 400);
                //modelInfo.AttackRange = (ushort)Random.Next(0, 10);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeEncounterTable(string tablePath, string fieldPackPath)
        {
            var table = TableSerializer.Deserialize<EncounterTable>(tablePath);

            var values = GetTableDistinctValues(table);
            var fieldAndRoomIds = GetFieldAndRoomIds(fieldPackPath);

            var encounterValues = (Dictionary<string, List<object>>)values[nameof(table.Encounters)][0];
            for (var i = 0; i < table.Encounters.Length; i++)
            {
                ref var e = ref table.Encounters[i];
                //e.EncounterFlags = 1;
                e.EncounterFlags = 0b0001000110100010;
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

        private static void RandomizeEncounterTableFES(string tablePath, string fieldPackPath)
        {
            var table = TableSerializer.Deserialize<EncounterTableF>(tablePath);

            var values = GetTableDistinctValues(table);
            var fieldAndRoomIds = GetFieldAndRoomIds(fieldPackPath);

            var encounterValues = (Dictionary<string, List<object>>)values[nameof(table.Encounters)][0];
            for (var i = 0; i < table.Encounters.Length; i++)
            {
                ref var e = ref table.Encounters[i];
                //e.EncounterFlags = 1;
                e.EncounterFlags = 0b0001000110100010;
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

        private static void RandomizeEncounterTableBossRush(string tablePath, string fieldPackPath)
        {
            var table = TableSerializer.Deserialize<EncounterTable>(tablePath);

            var values = GetTableDistinctValues(table);
            var fieldAndRoomIds = GetFieldAndRoomIds(fieldPackPath);

            var encounterValues = (Dictionary<string, List<object>>)values[nameof(table.Encounters)][0];
            for (var i = 0; i < table.Encounters.Length; i++)
            {
                ref var e = ref table.Encounters[i];
                e.EncounterFlags = 1;
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

            TableSerializer.Serialize(table, tablePath + "_Bossrush_Randomized");
        }

        private static void RandomizeEncounterTableBossRushFES(string tablePath, string fieldPackPath)
        {
            var table = TableSerializer.Deserialize<EncounterTableF>(tablePath);

            var values = GetTableDistinctValues(table);
            var fieldAndRoomIds = GetFieldAndRoomIds(fieldPackPath);

            var encounterValues = (Dictionary<string, List<object>>)values[nameof(table.Encounters)][0];
            for (var i = 0; i < table.Encounters.Length; i++)
            {
                ref var e = ref table.Encounters[i];
                e.EncounterFlags = 1;
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

            TableSerializer.Serialize(table, tablePath + "_Bossrush_Randomized");
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

            table.BattleMessageScript = ScriptRandomizer.RandomizeMessageScript(table.BattleMessageScript);

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static List<Tuple<ushort, ushort>> GetFieldAndRoomIds(string fieldpath)
        {
            var fieldAndRoomIds = new List<Tuple<ushort, ushort>>();

            foreach (string file in Directory.EnumerateFiles(fieldpath, "*.FPC"))
            {
                string fileName = Path.GetFileName(file); // F001_001
                ushort fieldId = ushort.Parse(fileName.Substring(1, 3)); // F<001>_001
                ushort roomId = ushort.Parse(fileName.Substring(5, 3)); // F001_<001>
                fieldAndRoomIds.Add(new Tuple<ushort, ushort>(fieldId, roomId));
            }

            return fieldAndRoomIds;
        }
    }
}
