using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
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
        public ushort CriticalHitCount { get; set; }

        [TableMember(FixedArrayLength = PARTY_MAX_CRIT)]
        public ushort[] CriticalHitTimings { get; set; }

        [TableMember]
        public ushort AssistHitCount { get; set; }

        [TableMember(FixedArrayLength = PARTY_MAX_ASSIST)]
        public ushort[] AssistHitTimings { get; set; }

        [TableMember(FixedArrayLength = PARTY_MAX_ANIM)]
        public ModelAnimationProperties[] AnimationProperties { get; set; }

        [TableMember]
        public ushort AttackRange { get; set; }
    }
}