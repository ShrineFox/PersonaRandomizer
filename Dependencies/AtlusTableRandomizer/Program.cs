using System;
using System.Collections.Generic;
using System.IO;
using AtlusTableLib.Serialization;
using TGELib.IO;
using AtlusTableLib.Persona5;
using System.Linq;

namespace AtlusTableRandomizer
{
    public class Program
    {
        public static Random Random = new Random();

        static void Main(string[] args)
        {

        }

        public static void Randomize(string tableDirectoryPath, bool[] options, bool bossRush = false, string excludedUnits = "")
        {
            foreach (var path in Directory.EnumerateFiles(tableDirectoryPath, "*.TBL"))
            {
                switch (Path.GetFileNameWithoutExtension(path).ToUpperInvariant())
                {
                    case "ENCOUNT":
                        if (options[0])
                        {
                            RandomizeEncounterTable(path, bossRush, excludedUnits);
                        }
                        break;

                    case "PERSONA":
                        if (options[1])
                        {
                            RandomizePersonaTable(path);
                        }
                        break;

                    case "UNIT":
                        if (options[2])
                        {
                            RandomizeUnitTable(path);
                        }
                        break;

                    case "SKILL":
                        if (options[3])
                        {
                            RandomizeSkillTable(path);
                        }
                        break;

                    case "ITEM":
                        if (options[4])
                        {
                            RandomizeItemTable(path);
                        }
                        break;

                    case "NAME":
                        if (options[5])
                        {
                            RandomizeNameTable(path);
                        }
                        break;

                    case "ELSAI":
                        RandomizeElsaiTable(path);
                        break;
                }
            }
        }

        private static void RandomizeElsaiTable(string tablePath)
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.ElsaiTable>(tablePath);

            var ais = new List<ushort>();

            foreach (var ai in table.Segment1)
            {
                if (!ais.Contains(ai.AiId))
                    ais.Add(ai.AiId);
            }

            for (int i = 0; i < table.Segment1.Length; i++)
            {
                ref var ai = ref table.Segment1[i];

                ai.AiId = GetRandom(ais);
            }

            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }

        private static void RandomizeEncounterTable(string tablePath, bool bossRush, string excludedUnits = "")
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.EncounterTable>(tablePath);

            var encounterTypes = new List<ushort>();
            var field02s = new List<ushort>();
            var field04s = new List<ushort>();
            var field06s = new List<ushort>();
            var unitIds = new List<ushort>();
            var fieldAndRoomIds = new List<Tuple<ushort, ushort>>();
            var musicIds = new List<ushort>();

            foreach (var encounter in table.Encounters)
            {
                if (!encounterTypes.Contains(encounter.EncounterType))
                    encounterTypes.Add(encounter.EncounterType);

                if (!field02s.Contains(encounter.Field02))
                    field02s.Add(encounter.Field02);

                if (!field04s.Contains(encounter.Field04))
                    field04s.Add(encounter.Field04);

                if (!field06s.Contains(encounter.Field06))
                    field06s.Add(encounter.Field06);

                for (int i = 0; i < encounter.UnitIDs.Length; i++)
                {
                    if (encounter.UnitIDs[i] != 0)
                        if (!unitIds.Contains(encounter.UnitIDs[i]))
                        {
                            unitIds.Add(encounter.UnitIDs[i]);
                        }
                }

                var fieldAndRoomTuple = new Tuple<ushort, ushort>(encounter.FieldId, encounter.RoomId);
                if (!fieldAndRoomIds.Contains(fieldAndRoomTuple))
                    fieldAndRoomIds.Add(fieldAndRoomTuple);

                if (!musicIds.Contains(encounter.MusicId))
                    musicIds.Add(encounter.MusicId);
            }

            for (int i = 0; i < table.Encounters.Length; i++)
            {
                ref var encounter = ref table.Encounters[i];

                //encounter.EncounterType = GetRandom(encounterTypes);
                //encounter.Field02 = GetRandom(field02s);
                //encounter.Field04 = GetRandom(field04s);
                //encounter.Field06 = GetRandom(field06s);
                if (bossRush)
                {
                    encounter.EncounterType = 0;
                    encounter.Field02 = 0;
                    encounter.Field04 = 0;
                    encounter.Field06 = 0;
                }
                /*
                if (bossRushAlt)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        encounter.UnitIDs[j] = 0;
                    }

                    encounter.UnitIDs[0] = (ushort)Random.Next(190, 351);
                }
                else
                {*/
                for (int j = 0; j < Random.Next(5); j++)
                {
                    if (bossRush)
                    {
                        encounter.UnitIDs[j] = (ushort)Random.Next(190, 351);
                    }
                    else
                    {
                        ushort randomUnitID = GetRandom(unitIds); // Get initial random value
                        ushort[] excludedUnitIDs = Array.ConvertAll(excludedUnits.Split(' '), s => ushort.Parse(s)); // Get list of excluded values

                        while (excludedUnitIDs.Any(x => x.Equals(randomUnitID)))
                            randomUnitID = GetRandom(unitIds); // Ensure random value doesn't include excluded unit
                        encounter.UnitIDs[j] = randomUnitID;
                    }
                }

                var fieldAndRoomTuple = GetRandom(fieldAndRoomIds);
                encounter.FieldId = fieldAndRoomTuple.Item1;
                encounter.RoomId = fieldAndRoomTuple.Item2;
                encounter.MusicId = GetRandom(musicIds);
            }
            

            TableSerializer.Serialize(table, output, Endianness.BigEndian);

        }

        private static void RandomizePersonaTable(string tablePath)
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.PersonaTable>(tablePath);

            var arcanas = new List<byte>();
            var levels = new List<byte>();
            var stats = new List<Stats>();

            foreach (var persona in table.PersonaInfo)
            {
                if (!arcanas.Contains(persona.Arcana))
                    arcanas.Add(persona.Arcana);

                if (!levels.Contains(persona.Level))
                    levels.Add(persona.Level);

                if (!stats.Contains(persona.Stats))
                    stats.Add(persona.Stats);
            }

            for (int i = 0; i < table.PersonaInfo.Length; i++)
            {
                ref var persona = ref table.PersonaInfo[i];

                persona.Arcana = GetRandom(arcanas);
                persona.Level = GetRandom(levels);
                persona.Stats = GetRandom(stats);
            }

            foreach (var skillSet in table.PersonaSkillSets)
            {
                for (int i = 0; i < skillSet.Skills.Length; i++)
                {
                    skillSet.Skills[i].SkillId = (ushort)Random.Next(1, 999);
                }
            }

            foreach (var persona in table.PartyPersonas)
            {
                for (int i = 0; i < persona.Skills.Length; i++)
                {
                    persona.Skills[i].SkillId = (ushort)Random.Next(1, 999);
                }
            }

            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }
        private static void RandomizeUnitTable(string tablePath)
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.UnitTable>(tablePath);

            string[] strings = new string[500];

            for (int i = 0; i < table.Units.Length; i++)
            {
                strings[i] = i + ":\t";

                var unit = table.Units[i];
                var properties = unit.GetType().GetProperties();

                foreach (var property in properties)
                {
                    strings[i] = strings[i] + property.GetValue(unit) + "\t";
                }
            }

            File.WriteAllLines(tablePath + ".txt", strings);

            /*
            var arcanas = new List<byte>();
            var levels = new List<byte>();
            var hps = new List<int>();
            var sps = new List<int>();
            var stats = new List<Stats>();
            var expRewards = new List<ushort>();
            var moneyRewards = new List<ushort>();
            var affinities = new List<AffinityFlags[]>();
            var personaAffinities = new List<AffinityFlags[]>();

            foreach (var unit in table.Units)
            {
                if (!arcanas.Contains(unit.Arcana))
                    arcanas.Add(unit.Arcana);

                if (!levels.Contains(unit.Level))
                    levels.Add(unit.Level);

                if (!hps.Contains(unit.Hp))
                    hps.Add(unit.Hp);

                if (!sps.Contains(unit.Sp))
                    sps.Add(unit.Sp);

                if (!stats.Contains(unit.Stats))
                    stats.Add(unit.Stats);

                if (!expRewards.Contains(unit.ExpReward))
                    expRewards.Add(unit.ExpReward);

                if (!moneyRewards.Contains(unit.MoneyReward))
                    moneyRewards.Add(unit.MoneyReward);
            }

            foreach (var affinity in table.Affinities)
            {
                if (!affinities.Contains(affinity.AffinityFlags))
                    affinities.Add(affinity.AffinityFlags);
            }

            foreach (var affinity in table.PersonaAffinities)
            {
                if (!personaAffinities.Contains(affinity.AffinityFlags))
                    personaAffinities.Add(affinity.AffinityFlags);
            }

            for (int i = 0; i < table.Units.Length; i++)
            {
                ref var unit = ref table.Units[i];

                unit.Arcana = GetRandom(arcanas);
                unit.Level = GetRandom(levels);
                unit.Hp = GetRandom(hps);
                unit.Sp = GetRandom(sps);
                unit.Stats = GetRandom(stats);
                unit.ExpReward = GetRandom(expRewards);
                unit.MoneyReward = GetRandom(moneyRewards);

                for (int j = 0; j < 8; j++)
                {
                    unit.SkillIDs[j] = (ushort)Random.Next(0, 999);
                }
            }

            for (int i = 0; i < table.Affinities.Length; i++)
            {
                ref var affinity = ref table.Affinities[i];

                affinity.AffinityFlags = GetRandom(affinities);
            }

            for (int i = 0; i < table.PersonaAffinities.Length; i++)
            {
                ref var affinity = ref table.PersonaAffinities[i];

                affinity.AffinityFlags = GetRandom(personaAffinities);
            }
            */
            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }

        private static void RandomizeSkillTable(string tablePath)
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.SkillTable>(tablePath);

            for (int i = 0; i < table.Skills.Length; i++)
            {
                var temp = table.Skills[i];
                int rand = Random.Next(i, table.Skills.Length);
                table.Skills[i] = table.Skills[rand];
                table.Skills[rand] = temp;
            }

            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }

        private static void RandomizeItemTable(string tablePath)
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.ItemTable>(tablePath);

            Shuffle(table.Accessories);
            Shuffle(table.Protectors);
            Shuffle(table.Consumables);
            Shuffle(table.Materials);
            Shuffle(table.MeleeWeapons);
            Shuffle(table.Outfits);
            Shuffle(table.SkillCards);
            Shuffle(table.RangedWeapons);

            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }

        private static void RandomizeNameTable(string tablePath)
        {
            string output = tablePath + "_Randomized";
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.NameTable>(tablePath);

            Shuffle(table.ArcanaNames);
            Shuffle(table.SkillNames);
            Shuffle(table.UnitNames);
            Shuffle(table.PersonaNames);
            Shuffle(table.AccessoryNames);
            Shuffle(table.ArmorNames);
            Shuffle(table.ConsumableItemNames);
            Shuffle(table.KeyItemNames);
            Shuffle(table.MaterialNames);
            Shuffle(table.MeleeWeaponNames);
            Shuffle(table.BattleActionNames);
            Shuffle(table.OutfitNames);
            Shuffle(table.SkillCardNames);
            Shuffle(table.ConfidantNames);
            Shuffle(table.PartyMemberLastNames);
            Shuffle(table.PartyMemberFirstNames);
            Shuffle(table.RangedWeaponNames);

            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }

        private static T GetRandom<T>(List<T> list)
        {
            return list[Random.Next(list.Count)];
        }

        private static void Shuffle<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var temp = array[i];
                int rand = Random.Next(i, array.Length - 1);
                array[i] = array[rand];
                array[rand] = temp;
            }
        }
    }
}
