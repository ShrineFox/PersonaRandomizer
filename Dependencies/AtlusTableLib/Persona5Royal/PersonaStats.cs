using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona5Royal
{
    public struct PersonaStats
    {
        [TableMember]
        public ushort Flags { get; set; }

        [TableMember]
        public byte Arcana { get; set; }

        [TableMember]
        public byte Level { get; set; }

        [TableMember]
        public Stats Stats { get; set; }

        [TableMember]
        public ushort Flags2 { get; set; }

        [TableMember]
        public ushort Flags3 { get; set; }

        [TableMember]
        public byte FusionMessageIndex { get; set; }
    }
}