using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona4
{
    public struct ModelAnimationProperties
    {
        [TableMember]
        public ushort Field00 { get; set; }

        [TableMember]
        public ushort Speed1 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Speed2 { get; set; }

        [TableMember]
        public ushort Field08 { get; set; }
    }
}
