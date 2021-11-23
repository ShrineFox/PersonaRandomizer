using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona5Royal
{
    public struct Stats
    {
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
    }
}
