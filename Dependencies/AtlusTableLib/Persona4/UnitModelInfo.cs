using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    public struct UnitModelInfo
    {
        [TableMember]
        public ModelPivot NeutralPivot { get; set; }

        [TableMember]
        public ModelPivot DownedPivot { get; set; }

        [TableMember]
        public ushort Scale { get; set; }

        [TableMember]
        public ushort Field16 { get; set; }

        [TableMember]
        public byte Field18 { get; set; }

        [TableMember]
        public byte Field19 { get; set; }

        [TableMember]
        public ushort AttackHitCount { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember]
        public ushort Field24 { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public ushort Field28 { get; set; }

        [TableMember(FixedArrayLength = UNIT_MAX_ANIM)]
        public ModelAnimationProperties[] AnimationProperties { get; set; }
    }
}