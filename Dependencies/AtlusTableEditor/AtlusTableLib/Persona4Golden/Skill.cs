using AtlusTableLib.Persona4;
using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona4Golden
{
    public struct Skill
    {
        [TableMember]
        public byte Field00 { get; set; }

        [TableMember]
        public byte Field01 { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public byte Field04 { get; set; }

        [TableMember]
        public SkillUsageDrainType DrainType { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Cost { get; set; }

        [TableMember]
        public ushort Field09 { get; set; }

        [TableMember]
        public SkillTargetSelectionMode TargetSelectionMode { get; set; }

        [TableMember]
        public SkillTargetFilterFlags TargetFilterFlags { get; set; }

        [TableMember]
        public ushort Field0D { get; set; }

        [TableMember]
        public ushort Field0E { get; set; }

        [TableMember]
        public byte Accuracy { get; set; }

        [TableMember]
        public byte Field12 { get; set; }

        [TableMember]
        public byte Field13 { get; set; }

        [TableMember]
        public SkillPowerType HpPowerType { get; set; }

        [TableMember]
        public ushort HpPower { get; set; }

        [TableMember]
        public SkillPowerType SpPowerType { get; set; }

        [TableMember]
        public byte Field18 { get; set; }

        [TableMember]
        public ushort SpPower { get; set; }

        [TableMember]
        public byte ChanceType { get; set; }

        [TableMember]
        public ushort Chance { get; set; }

        [TableMember]
        public SkillAilmentFlags AilmentFlags { get; set; }

        [TableMember]
        public SkillAdditionalEffectFlags AdditionalEffectFlags { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember]
        public SkillStatusEffectFlags StatusEffectFlags { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public byte CriticalChance { get; set; }

        [TableMember]
        public ushort Field29 { get; set; }
    }
}