using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    public struct PersonaModelInfo
    {
        [TableMember]
        public ushort PositionX1 { get; set; }

        [TableMember]
        public ushort PositionY1 { get; set; }

        [TableMember]
        public ushort PositionZ1 { get; set; }

        [TableMember]
        public ushort PositionX2 { get; set; }

        [TableMember]
        public ushort PositionY2 { get; set; }

        [TableMember]
        public ushort PositionZ2 { get; set; }

        [TableMember]
        public ushort PositionX3 { get; set; }

        [TableMember]
        public ushort PositionY3 { get; set; }

        [TableMember]
        public ushort PositionZ3 { get; set; }

        [TableMember]
        public ushort PositionX4 { get; set; }

        [TableMember]
        public ushort PositionY4 { get; set; }

        [TableMember]
        public ushort PositionZ4 { get; set; }

        [TableMember(FixedArrayLength = PERSONA_MAX_ANIM)]
        public ModelAnimationProperties[] AnimationProperties { get; set; }

        [TableMember]
        public ushort Scale { get; set; }

        [TableMember]
        public ushort AttackRange { get; set; }
    }
}