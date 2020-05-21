using System;
using System.Collections.Generic;
using AtlusTableLib.Serialization;
using TGELib.IO;

namespace AtlusTableRandomizer
{
    class Program
    {
        public static Random Random = new Random();

        static void Main(string[] args)
        {
            var path = @"D:\Modding\Persona 5 EU\Main game\Extracted\data\battle\_table\ENCOUNT.TBL";

            for (int i = 0; i < 5; i++)
            {
                Randomize(path, path + ".random" + i);
            }

            for (int i = 0; i < 5; i++)
            {
                Randomize(path, path + ".random_BOSSRUSH" + i, false, true);
            }
        }

        private static void Randomize(string path, string output, bool bossRush = false, bool bossRushAlt = false, bool goroOnly = false)
        {
            var table = TableSerializer.Deserialize<AtlusTableLib.Persona5.EncounterTable>(path);

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
                    if (!unitIds.Contains(encounter.UnitIDs[i]))
                        unitIds.Add(encounter.UnitIDs[i]);
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

                if (bossRushAlt)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        encounter.UnitIDs[j] = 0;
                    }

                    encounter.UnitIDs[0] = (ushort)Random.Next(190, 351);
                }
                else
                {
                    for (int j = 0; j < Random.Next(5); j++)
                    {
                        if (bossRush)
                        {
                            encounter.UnitIDs[j] = (ushort) Random.Next(190, 351);
                        }
                        else
                        {
                            encounter.UnitIDs[j] = GetRandom(unitIds);
                        }
                    }
                }

                var fieldAndRoomTuple = GetRandom(fieldAndRoomIds);
                encounter.FieldId = fieldAndRoomTuple.Item1;
                encounter.RoomId = fieldAndRoomTuple.Item2;
                encounter.MusicId = GetRandom(musicIds);
            }

            TableSerializer.Serialize(table, output, Endianness.BigEndian);
        }

        private static T GetRandom<T>(List<T> list)
        {
            return list[Random.Next(list.Count)];
        }
    }
}
