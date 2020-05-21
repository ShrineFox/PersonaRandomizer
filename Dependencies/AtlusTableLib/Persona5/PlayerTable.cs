using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    [Table(Game.Persona5PS3JP, Game.Persona5PS3NA, Game.Persona5PS3EU, Game.Persona5PS4JP, Game.Persona5PS4NA, Game.Persona5PS4EU, Name = TABLE_NAME_PLAYER)]
    public class PlayerTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = MAX_LEVEL)]
        public int[] LevelExpRequirements { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = MAX_LEVEL)]
        public LevelStats[] LevelStats { get; set; }
    }

    public struct LevelStats
    {
        [TableMember]
        public short Field00 { get; set; }

        [TableMember]
        public short Field02 { get; set; }

        [TableMember]
        public short Field04 { get; set; }

        [TableMember]
        public short Field06 { get; set; }

        [TableMember]
        public short Field08 { get; set; }

        [TableMember]
        public short Field0A { get; set; }

        [TableMember]
        public short Field0C { get; set; }

        [TableMember]
        public short Field0E { get; set; }

        [TableMember]
        public short Field10 { get; set; }

        [TableMember]
        public short Field12 { get; set; }

        [TableMember]
        public short Field14 { get; set; }

        [TableMember]
        public short Field16 { get; set; }

        [TableMember]
        public short Field18 { get; set; }

        [TableMember]
        public short Field1A { get; set; }

        [TableMember]
        public short Field1C { get; set; }

        [TableMember]
        public short Field1E { get; set; }

        [TableMember]
        public short Field20 { get; set; }

        [TableMember]
        public short Field22 { get; set; }

        [TableMember]
        public short Field24 { get; set; }

        [TableMember]
        public short Field26 { get; set; }

        [TableMember]
        public short Field28 { get; set; }

        [TableMember]
        public short Field2A { get; set; }
    }
}
