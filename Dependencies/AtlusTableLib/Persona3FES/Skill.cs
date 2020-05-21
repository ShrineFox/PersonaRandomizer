using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    public struct Skill
    {
        [TableMember]
        public byte Field00 { get; set; }

        [TableMember]
        public byte Field01 { get; set; }

        [TableMember]
        public SkillUsageDrainType DrainType { get; set; }

        [TableMember]
        public byte Field03 { get; set; }

        [TableMember]
        public ushort Cost { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public SkillTargetSelectionMode TargetSelectionMode { get; set; }

        [TableMember]
        public SkillTargetFilterFlags TargetFilterFlags { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public byte Accuracy { get; set; }

        [TableMember]
        public byte Field0F { get; set; }

        [TableMember]
        public byte Field10 { get; set; }

        [TableMember]
        public SkillPowerType HpPowerType { get; set; }

        [TableMember]
        public ushort HpPower { get; set; }

        [TableMember]
        public SkillPowerType SpPowerType { get; set; }

        [TableMember]
        public byte Field15 { get; set; }

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
        public ushort Field1F { get; set; }

        [TableMember]
        public SkillStatusEffectFlags StatusEffectFlags { get; set; }

        [TableMember]
        public ushort Field23 { get; set; }

        [TableMember]
        public byte CriticalChance { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public ushort Field28 { get; set; }

        [TableMember]
        public ushort Field2B { get; set; }
    }
}
