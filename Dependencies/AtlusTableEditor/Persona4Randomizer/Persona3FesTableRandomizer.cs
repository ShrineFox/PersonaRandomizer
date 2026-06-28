using System;
using System.Collections.Generic;
using System.IO;
using AtlusScriptLib;
using AtlusTableLib.Serialization;
using AtlusTableLib.Persona3FES;
using System.Linq;

namespace AtlusRandomizer
{
    public class Persona3FesTableRandomizer : TableRandomizer
    {
        public static void Randomize(string tableDirectoryPath, List<string> options, bool bossrush = false)
        {
            if (!Directory.Exists(tableDirectoryPath))
                return;

            foreach (var path in Directory.EnumerateFiles(tableDirectoryPath, "*.TBL"))
            {
                switch (Path.GetFileNameWithoutExtension(path).ToUpperInvariant())
                {
                    case "AICALC":
                        if (options.Any(x => x.Equals("AICALC")))
                            RandomizeAICalculationTable(path);
                        break;

                    case "AICALC_F":
                        if (options.Any(x => x.Equals("AICALC_F")))
                            RandomizeAICalculationTableFES(path);
                        break;

                    case "ENCOUNT":
                        if (options.Any(x => x.Equals("ENCOUNT")))
                        {
                            if (bossrush)
                                RandomizeEncounterTableBossRush(path, path);
                            else
                                RandomizeEncounterTable(path, path);
                        }
                        break;

                    case "ENCOUNT_F":
                        if (options.Any(x => x.Equals("ENCOUNT_F")))
                        {
                            if (bossrush)
                                RandomizeEncounterTableBossRushFES(path, path);
                            else
                                RandomizeEncounterTableFES(path, path);
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

                    case "PERSONA_F":
                        if (options.Any(x => x.Equals("PERSONA_F")))
                            RandomizePersonaTableFES(path);
                        break;

                    case "SKILL":
                        if (options.Any(x => x.Equals("SKILL")))
                            RandomizeSkillTable(path);
                        break;

                    case "SKILL_F":
                        if (options.Any(x => x.Equals("SKILL_F")))
                            RandomizeSkillTableFES(path);
                        break;

                    case "UNIT":
                        if (options.Any(x => x.Equals("UNIT")))
                            RandomizeUnitTable(path);
                        break;

                    case "UNIT_F":
                        if (options.Any(x => x.Equals("UNIT_F")))
                            RandomizeUnitTableFES(path);
                        break;
                }
            }
        }

        private static void RandomizeAICalculationTable(string tablePath)
        {
            var table = TableSerializer.Deserialize<AICalculationTable>(tablePath);
            if (IsAPIKeyValid())
            {
                table.PlayerAIScript = ScriptRandomizer.RandomizeFlowScript(table.PlayerAIScript);
                table.BossAIScript = ScriptRandomizer.RandomizeFlowScript(table.BossAIScript);
            }

            TableSerializer.Serialize(table, tablePath + "_Randomized");
        }

        private static void RandomizeAICalculationTableFES(string tablePath)
        {
            var table = TableSerializer.Deserialize<AICalculationTableF>(tablePath);
            if (IsAPIKeyValid())
            {
                table.PlayerAIScript = ScriptRandomizer.RandomizeFlowScript(table.PlayerAIScript);
                table.BossAIScript = ScriptRandomizer.RandomizeFlowScript(table.BossAIScript);
            }

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

                var fieldAndRoomTuple = GetRandom<Tuple<ushort, ushort>>(p3fesfields);
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

                var fieldAndRoomTuple = GetRandom<Tuple<ushort, ushort>>(p3fesfields);
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

                var fieldAndRoomTuple = GetRandom<Tuple<ushort, ushort>>(p3fesfields);
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

                var fieldAndRoomTuple = GetRandom<Tuple<ushort, ushort>>(p3fesfields);
                e.FieldId = fieldAndRoomTuple.Item1;
                e.RoomId = fieldAndRoomTuple.Item2;
                e.MusicId = (ushort)Random.Next(0, 11);
            }

            TableSerializer.Serialize(table, tablePath + "_Bossrush_Randomized");
        }

        private static void RandomizeMessageTable(string tablePath)
        {
            if (!IsAPIKeyValid())
                return;

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

        public static List<Tuple<ushort, ushort>> p3fesfields = new List<Tuple<ushort, ushort>>()
        {
            new Tuple<ushort, ushort>(000, 000),
            new Tuple<ushort, ushort>(000, 002),
            new Tuple<ushort, ushort>(001, 000),
            new Tuple<ushort, ushort>(001, 001),
            new Tuple<ushort, ushort>(004, 002),
            new Tuple<ushort, ushort>(004, 003),
            new Tuple<ushort, ushort>(004, 004),
            new Tuple<ushort, ushort>(004, 005),
            new Tuple<ushort, ushort>(004, 006),
            new Tuple<ushort, ushort>(004, 007),
            new Tuple<ushort, ushort>(004, 010),
            new Tuple<ushort, ushort>(005, 001),
            new Tuple<ushort, ushort>(005, 002),
            new Tuple<ushort, ushort>(005, 003),
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
            new Tuple<ushort, ushort>(006, 018),
            new Tuple<ushort, ushort>(006, 019),
            new Tuple<ushort, ushort>(006, 020),
            new Tuple<ushort, ushort>(006, 021),
            new Tuple<ushort, ushort>(006, 022),
            new Tuple<ushort, ushort>(006, 023),
            new Tuple<ushort, ushort>(007, 001),
            new Tuple<ushort, ushort>(007, 002),
            new Tuple<ushort, ushort>(007, 003),
            new Tuple<ushort, ushort>(007, 004),
            new Tuple<ushort, ushort>(007, 005),
            new Tuple<ushort, ushort>(007, 006),
            new Tuple<ushort, ushort>(007, 007),
            new Tuple<ushort, ushort>(007, 008),
            new Tuple<ushort, ushort>(007, 009),
            new Tuple<ushort, ushort>(007, 010),
            new Tuple<ushort, ushort>(007, 011),
            new Tuple<ushort, ushort>(007, 012),
            new Tuple<ushort, ushort>(007, 013),
            new Tuple<ushort, ushort>(007, 014),
            new Tuple<ushort, ushort>(007, 015),
            new Tuple<ushort, ushort>(007, 016),
            new Tuple<ushort, ushort>(007, 017),
            new Tuple<ushort, ushort>(007, 018),
            new Tuple<ushort, ushort>(008, 001),
            new Tuple<ushort, ushort>(008, 002),
            new Tuple<ushort, ushort>(008, 003),
            new Tuple<ushort, ushort>(008, 004),
            new Tuple<ushort, ushort>(008, 005),
            new Tuple<ushort, ushort>(008, 006),
            new Tuple<ushort, ushort>(008, 007),
            new Tuple<ushort, ushort>(008, 008),
            new Tuple<ushort, ushort>(008, 009),
            new Tuple<ushort, ushort>(009, 001),
            new Tuple<ushort, ushort>(009, 002),
            new Tuple<ushort, ushort>(009, 003),
            new Tuple<ushort, ushort>(009, 004),
            new Tuple<ushort, ushort>(009, 005),
            new Tuple<ushort, ushort>(009, 006),
            new Tuple<ushort, ushort>(009, 007),
            new Tuple<ushort, ushort>(010, 001),
            new Tuple<ushort, ushort>(010, 002),
            new Tuple<ushort, ushort>(010, 003),
            new Tuple<ushort, ushort>(012, 001),
            new Tuple<ushort, ushort>(013, 001),
            new Tuple<ushort, ushort>(013, 002),
            new Tuple<ushort, ushort>(013, 003),
            new Tuple<ushort, ushort>(014, 001),
            new Tuple<ushort, ushort>(014, 002),
            new Tuple<ushort, ushort>(014, 003),
            new Tuple<ushort, ushort>(014, 004),
            new Tuple<ushort, ushort>(014, 005),
            new Tuple<ushort, ushort>(014, 006),
            new Tuple<ushort, ushort>(014, 007),
            new Tuple<ushort, ushort>(014, 008),
            new Tuple<ushort, ushort>(014, 009),
            new Tuple<ushort, ushort>(014, 010),
            new Tuple<ushort, ushort>(015, 001),
            new Tuple<ushort, ushort>(015, 002),
            new Tuple<ushort, ushort>(015, 003),
            new Tuple<ushort, ushort>(015, 004),
            new Tuple<ushort, ushort>(015, 005),
            new Tuple<ushort, ushort>(015, 006),
            new Tuple<ushort, ushort>(015, 007),
            new Tuple<ushort, ushort>(015, 008),
            new Tuple<ushort, ushort>(015, 009),
            new Tuple<ushort, ushort>(015, 010),
            new Tuple<ushort, ushort>(016, 001),
            new Tuple<ushort, ushort>(016, 002),
            new Tuple<ushort, ushort>(016, 003),
            new Tuple<ushort, ushort>(016, 004),
            new Tuple<ushort, ushort>(016, 005),
            new Tuple<ushort, ushort>(020, 001),
            new Tuple<ushort, ushort>(020, 002),
            new Tuple<ushort, ushort>(020, 003),
            new Tuple<ushort, ushort>(020, 004),
            new Tuple<ushort, ushort>(020, 005),
            new Tuple<ushort, ushort>(020, 006),
            new Tuple<ushort, ushort>(020, 007),
            new Tuple<ushort, ushort>(020, 008),
            new Tuple<ushort, ushort>(020, 009),
            new Tuple<ushort, ushort>(020, 010),
            new Tuple<ushort, ushort>(020, 011),
            new Tuple<ushort, ushort>(020, 012),
            new Tuple<ushort, ushort>(020, 013),
            new Tuple<ushort, ushort>(020, 014),
            new Tuple<ushort, ushort>(020, 015),
            new Tuple<ushort, ushort>(020, 016),
            new Tuple<ushort, ushort>(020, 017),
            new Tuple<ushort, ushort>(020, 018),
            new Tuple<ushort, ushort>(020, 019),
            new Tuple<ushort, ushort>(021, 000),
            new Tuple<ushort, ushort>(021, 001),
            new Tuple<ushort, ushort>(021, 002),
            new Tuple<ushort, ushort>(021, 003),
            new Tuple<ushort, ushort>(021, 004),
            new Tuple<ushort, ushort>(021, 005),
            new Tuple<ushort, ushort>(021, 006),
            new Tuple<ushort, ushort>(021, 007),
            new Tuple<ushort, ushort>(021, 008),
            new Tuple<ushort, ushort>(021, 009),
            new Tuple<ushort, ushort>(021, 011),
            new Tuple<ushort, ushort>(021, 013),
            new Tuple<ushort, ushort>(021, 014),
            new Tuple<ushort, ushort>(021, 016),
            new Tuple<ushort, ushort>(021, 017),
            new Tuple<ushort, ushort>(021, 018),
            new Tuple<ushort, ushort>(021, 019),
            new Tuple<ushort, ushort>(021, 030),
            new Tuple<ushort, ushort>(021, 050),
            new Tuple<ushort, ushort>(022, 000),
            new Tuple<ushort, ushort>(022, 001),
            new Tuple<ushort, ushort>(022, 002),
            new Tuple<ushort, ushort>(022, 003),
            new Tuple<ushort, ushort>(022, 004),
            new Tuple<ushort, ushort>(022, 005),
            new Tuple<ushort, ushort>(022, 006),
            new Tuple<ushort, ushort>(022, 007),
            new Tuple<ushort, ushort>(022, 008),
            new Tuple<ushort, ushort>(022, 018),
            new Tuple<ushort, ushort>(022, 050),
            new Tuple<ushort, ushort>(022, 051),
            new Tuple<ushort, ushort>(023, 000),
            new Tuple<ushort, ushort>(023, 001),
            new Tuple<ushort, ushort>(023, 002),
            new Tuple<ushort, ushort>(023, 003),
            new Tuple<ushort, ushort>(023, 004),
            new Tuple<ushort, ushort>(023, 005),
            new Tuple<ushort, ushort>(023, 006),
            new Tuple<ushort, ushort>(023, 007),
            new Tuple<ushort, ushort>(023, 008),
            new Tuple<ushort, ushort>(023, 018),
            new Tuple<ushort, ushort>(023, 050),
            new Tuple<ushort, ushort>(023, 051),
            new Tuple<ushort, ushort>(024, 000),
            new Tuple<ushort, ushort>(024, 001),
            new Tuple<ushort, ushort>(024, 002),
            new Tuple<ushort, ushort>(024, 003),
            new Tuple<ushort, ushort>(024, 004),
            new Tuple<ushort, ushort>(024, 005),
            new Tuple<ushort, ushort>(024, 006),
            new Tuple<ushort, ushort>(024, 007),
            new Tuple<ushort, ushort>(024, 008),
            new Tuple<ushort, ushort>(024, 018),
            new Tuple<ushort, ushort>(024, 050),
            new Tuple<ushort, ushort>(024, 051),
            new Tuple<ushort, ushort>(025, 000),
            new Tuple<ushort, ushort>(025, 001),
            new Tuple<ushort, ushort>(025, 002),
            new Tuple<ushort, ushort>(025, 003),
            new Tuple<ushort, ushort>(025, 004),
            new Tuple<ushort, ushort>(025, 005),
            new Tuple<ushort, ushort>(025, 006),
            new Tuple<ushort, ushort>(025, 007),
            new Tuple<ushort, ushort>(025, 008),
            new Tuple<ushort, ushort>(025, 018),
            new Tuple<ushort, ushort>(025, 050),
            new Tuple<ushort, ushort>(026, 000),
            new Tuple<ushort, ushort>(026, 001),
            new Tuple<ushort, ushort>(026, 002),
            new Tuple<ushort, ushort>(026, 003),
            new Tuple<ushort, ushort>(026, 004),
            new Tuple<ushort, ushort>(026, 005),
            new Tuple<ushort, ushort>(026, 006),
            new Tuple<ushort, ushort>(026, 007),
            new Tuple<ushort, ushort>(026, 008),
            new Tuple<ushort, ushort>(026, 018),
            new Tuple<ushort, ushort>(026, 050),
            new Tuple<ushort, ushort>(026, 051),
            new Tuple<ushort, ushort>(026, 052),
            new Tuple<ushort, ushort>(026, 053),
            new Tuple<ushort, ushort>(027, 000),
            new Tuple<ushort, ushort>(027, 001),
            new Tuple<ushort, ushort>(027, 002),
            new Tuple<ushort, ushort>(027, 003),
            new Tuple<ushort, ushort>(027, 004),
            new Tuple<ushort, ushort>(027, 005),
            new Tuple<ushort, ushort>(027, 006),
            new Tuple<ushort, ushort>(027, 007),
            new Tuple<ushort, ushort>(027, 008),
            new Tuple<ushort, ushort>(027, 018),
            new Tuple<ushort, ushort>(027, 050),
            new Tuple<ushort, ushort>(028, 000),
            new Tuple<ushort, ushort>(031, 001),
            new Tuple<ushort, ushort>(031, 002),
            new Tuple<ushort, ushort>(031, 003),
            new Tuple<ushort, ushort>(031, 004),
            new Tuple<ushort, ushort>(031, 005),
            new Tuple<ushort, ushort>(031, 006),
            new Tuple<ushort, ushort>(031, 007),
            new Tuple<ushort, ushort>(032, 001),
            new Tuple<ushort, ushort>(032, 002),
            new Tuple<ushort, ushort>(032, 003),
            new Tuple<ushort, ushort>(032, 004),
            new Tuple<ushort, ushort>(032, 005),
            new Tuple<ushort, ushort>(032, 006),
            new Tuple<ushort, ushort>(032, 007),
            new Tuple<ushort, ushort>(032, 008),
            new Tuple<ushort, ushort>(032, 009),
            new Tuple<ushort, ushort>(033, 001),
            new Tuple<ushort, ushort>(033, 002),
            new Tuple<ushort, ushort>(033, 003),
            new Tuple<ushort, ushort>(034, 001),
            new Tuple<ushort, ushort>(034, 002),
            new Tuple<ushort, ushort>(034, 003),
            new Tuple<ushort, ushort>(034, 004),
            new Tuple<ushort, ushort>(034, 005),
            new Tuple<ushort, ushort>(034, 006),
            new Tuple<ushort, ushort>(034, 007),
            new Tuple<ushort, ushort>(034, 008),
            new Tuple<ushort, ushort>(034, 009),
            new Tuple<ushort, ushort>(034, 010),
            new Tuple<ushort, ushort>(034, 011),
            new Tuple<ushort, ushort>(034, 012),
            new Tuple<ushort, ushort>(034, 013),
            new Tuple<ushort, ushort>(034, 014),
            new Tuple<ushort, ushort>(034, 015),
            new Tuple<ushort, ushort>(034, 016),
            new Tuple<ushort, ushort>(034, 017),
            new Tuple<ushort, ushort>(034, 018),
            new Tuple<ushort, ushort>(034, 019),
            new Tuple<ushort, ushort>(034, 020),
            new Tuple<ushort, ushort>(035, 001),
            new Tuple<ushort, ushort>(035, 002),
            new Tuple<ushort, ushort>(035, 003),
            new Tuple<ushort, ushort>(035, 004),
            new Tuple<ushort, ushort>(035, 005),
            new Tuple<ushort, ushort>(035, 006),
            new Tuple<ushort, ushort>(035, 007),
            new Tuple<ushort, ushort>(035, 008),
            new Tuple<ushort, ushort>(035, 009),
            new Tuple<ushort, ushort>(035, 010),
            new Tuple<ushort, ushort>(035, 011),
            new Tuple<ushort, ushort>(035, 012),
            new Tuple<ushort, ushort>(035, 013),
            new Tuple<ushort, ushort>(035, 014),
            new Tuple<ushort, ushort>(035, 015),
            new Tuple<ushort, ushort>(035, 016),
            new Tuple<ushort, ushort>(035, 017),
            new Tuple<ushort, ushort>(037, 001),
            new Tuple<ushort, ushort>(039, 001),
            new Tuple<ushort, ushort>(039, 002),
            new Tuple<ushort, ushort>(039, 003),
            new Tuple<ushort, ushort>(041, 000),
            new Tuple<ushort, ushort>(041, 050),
            new Tuple<ushort, ushort>(042, 000),
            new Tuple<ushort, ushort>(042, 050),
            new Tuple<ushort, ushort>(043, 000),
            new Tuple<ushort, ushort>(043, 050),
            new Tuple<ushort, ushort>(044, 000),
            new Tuple<ushort, ushort>(044, 050),
            new Tuple<ushort, ushort>(045, 000),
            new Tuple<ushort, ushort>(045, 050),
            new Tuple<ushort, ushort>(046, 050),
            new Tuple<ushort, ushort>(047, 050),
            new Tuple<ushort, ushort>(051, 001),
            new Tuple<ushort, ushort>(051, 002),
            new Tuple<ushort, ushort>(051, 003),
            new Tuple<ushort, ushort>(051, 004),
            new Tuple<ushort, ushort>(052, 001),
            new Tuple<ushort, ushort>(052, 002),
            new Tuple<ushort, ushort>(052, 003),
            new Tuple<ushort, ushort>(052, 004),
            new Tuple<ushort, ushort>(052, 005),
            new Tuple<ushort, ushort>(052, 006),
            new Tuple<ushort, ushort>(052, 007),
            new Tuple<ushort, ushort>(053, 001),
            new Tuple<ushort, ushort>(053, 002),
            new Tuple<ushort, ushort>(053, 003),
            new Tuple<ushort, ushort>(053, 004),
            new Tuple<ushort, ushort>(054, 001),
            new Tuple<ushort, ushort>(054, 002),
            new Tuple<ushort, ushort>(054, 003),
            new Tuple<ushort, ushort>(054, 004),
            new Tuple<ushort, ushort>(055, 001),
            new Tuple<ushort, ushort>(055, 002),
            new Tuple<ushort, ushort>(055, 003),
            new Tuple<ushort, ushort>(055, 004),
            new Tuple<ushort, ushort>(055, 005),
            new Tuple<ushort, ushort>(056, 001),
            new Tuple<ushort, ushort>(056, 002),
            new Tuple<ushort, ushort>(056, 003),
            new Tuple<ushort, ushort>(056, 004),
            new Tuple<ushort, ushort>(056, 005),
            new Tuple<ushort, ushort>(071, 001),
            new Tuple<ushort, ushort>(071, 002),
            new Tuple<ushort, ushort>(071, 003),
            new Tuple<ushort, ushort>(071, 004),
            new Tuple<ushort, ushort>(071, 005),
            new Tuple<ushort, ushort>(071, 006),
            new Tuple<ushort, ushort>(072, 001),
            new Tuple<ushort, ushort>(072, 002),
            new Tuple<ushort, ushort>(072, 003),
            new Tuple<ushort, ushort>(072, 004),
            new Tuple<ushort, ushort>(073, 001),
            new Tuple<ushort, ushort>(073, 002),
            new Tuple<ushort, ushort>(073, 003),
            new Tuple<ushort, ushort>(073, 004),
            new Tuple<ushort, ushort>(073, 005),
            new Tuple<ushort, ushort>(073, 006),
            new Tuple<ushort, ushort>(074, 001),
            new Tuple<ushort, ushort>(074, 002),
            new Tuple<ushort, ushort>(074, 003),
            new Tuple<ushort, ushort>(074, 004),
            new Tuple<ushort, ushort>(075, 001),
            new Tuple<ushort, ushort>(075, 002),
            new Tuple<ushort, ushort>(075, 003),
            new Tuple<ushort, ushort>(075, 004),
            new Tuple<ushort, ushort>(075, 005),
            new Tuple<ushort, ushort>(200, 000),
            new Tuple<ushort, ushort>(221, 001),
            new Tuple<ushort, ushort>(221, 002),
            new Tuple<ushort, ushort>(221, 003),
            new Tuple<ushort, ushort>(222, 001),
            new Tuple<ushort, ushort>(222, 002),
            new Tuple<ushort, ushort>(223, 001),
            new Tuple<ushort, ushort>(223, 002),
            new Tuple<ushort, ushort>(224, 001),
            new Tuple<ushort, ushort>(224, 002),
            new Tuple<ushort, ushort>(224, 003),
            new Tuple<ushort, ushort>(225, 001),
            new Tuple<ushort, ushort>(225, 002),
            new Tuple<ushort, ushort>(226, 001),
            new Tuple<ushort, ushort>(226, 002),
            new Tuple<ushort, ushort>(227, 001),
            new Tuple<ushort, ushort>(227, 002),
            new Tuple<ushort, ushort>(228, 001),
            new Tuple<ushort, ushort>(228, 002),
            new Tuple<ushort, ushort>(230, 001),
            new Tuple<ushort, ushort>(230, 002),
            new Tuple<ushort, ushort>(231, 001),
            new Tuple<ushort, ushort>(231, 002),
            new Tuple<ushort, ushort>(232, 001),
            new Tuple<ushort, ushort>(232, 002),
            new Tuple<ushort, ushort>(232, 003),
            new Tuple<ushort, ushort>(232, 004),
            new Tuple<ushort, ushort>(232, 005),
            new Tuple<ushort, ushort>(232, 006),
            new Tuple<ushort, ushort>(232, 007),
            new Tuple<ushort, ushort>(234, 001),
            new Tuple<ushort, ushort>(234, 002),
            new Tuple<ushort, ushort>(234, 003),
            new Tuple<ushort, ushort>(235, 001),
            new Tuple<ushort, ushort>(235, 002),
            new Tuple<ushort, ushort>(235, 003),
            new Tuple<ushort, ushort>(236, 001),
            new Tuple<ushort, ushort>(237, 002),
            new Tuple<ushort, ushort>(237, 003),
            new Tuple<ushort, ushort>(238, 001),
            new Tuple<ushort, ushort>(239, 001),
            new Tuple<ushort, ushort>(239, 004),
            new Tuple<ushort, ushort>(239, 005),
            new Tuple<ushort, ushort>(241, 001),
            new Tuple<ushort, ushort>(242, 001),
            new Tuple<ushort, ushort>(243, 001),
            new Tuple<ushort, ushort>(244, 001),
            new Tuple<ushort, ushort>(245, 001),
            new Tuple<ushort, ushort>(251, 001),
            new Tuple<ushort, ushort>(251, 003),
            new Tuple<ushort, ushort>(252, 001),
            new Tuple<ushort, ushort>(253, 001),
            new Tuple<ushort, ushort>(254, 001),
            new Tuple<ushort, ushort>(255, 001),
            new Tuple<ushort, ushort>(256, 001),
            new Tuple<ushort, ushort>(257, 001),
            new Tuple<ushort, ushort>(271, 001),
            new Tuple<ushort, ushort>(272, 001),
            new Tuple<ushort, ushort>(273, 001),
            new Tuple<ushort, ushort>(274, 001),
            new Tuple<ushort, ushort>(275, 001)
        };
    }
}
