using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona4
{
    public struct ModelPivot
    {
        [TableMember]
        public ushort PositionX { get; set; }

        [TableMember]
        public ushort PositionY { get; set; }

        [TableMember]
        public ushort PositionZ { get; set; }

        [TableMember]
        public ushort Scale1 { get; set; }

        [TableMember]
        public ushort Scale2 { get; set; }
    }
}
