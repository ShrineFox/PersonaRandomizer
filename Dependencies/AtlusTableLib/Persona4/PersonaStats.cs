using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona4
{
    public struct PersonaStats
    {
        [TableMember]
        public ushort Flags1 { get; set; }

        [TableMember]
        public byte ArcanaIndex { get; set; }

        [TableMember]
        public byte Level { get; set; }

        [TableMember]
        public byte Strength { get; set; }

        [TableMember]
        public byte Magic { get; set; }

        [TableMember]
        public byte Endurance { get; set; }

        [TableMember]
        public byte Agility { get; set; }

        [TableMember]
        public byte Luck { get; set; }

        [TableMember]
        public ushort Flags2 { get; set; }

        [TableMember]
        public ushort Flags3 { get; set; }

        [TableMember]
        public byte FusionMessageIndex { get; set; }
    }
}