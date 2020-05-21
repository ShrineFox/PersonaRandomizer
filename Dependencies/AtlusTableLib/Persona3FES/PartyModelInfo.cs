using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    public struct PartyModelInfo
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
        public ushort Field18 { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember(FixedArrayLength = Constants.PARTY_MAX_ANIM)]
        public ModelAnimationProperties[] AnimationProperties { get; set; }
    }
}
