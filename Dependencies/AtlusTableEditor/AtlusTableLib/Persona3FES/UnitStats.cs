using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    public struct UnitStats
    {
        [TableMember]
        public byte Field00 { get; set; }

        [TableMember]
        public byte Field01 { get; set; }

        [TableMember]
        public byte ArcanaId { get; set; }

        [TableMember]
        public byte Level { get; set; }

        [TableMember]
        public ushort Hp { get; set; }

        [TableMember]
        public ushort Sp { get; set; }

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

        [TableMember]
        public byte Field0D { get; set; }

        [TableMember(FixedArrayLength = Constants.UNIT_MAX_SKILL)]
        public ushort[] SkillIDs { get; set; }

        [TableMember]
        public ushort ExpReward { get; set; }

        [TableMember]
        public ushort YenReward { get; set; }

        [TableMember]
        public byte Field22 { get; set; }

        [TableMember]
        public byte Field23 { get; set; }

        [TableMember]
        public byte Field24 { get; set; }

        [TableMember]
        public byte Field25 { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public ushort Field28 { get; set; }

        [TableMember]
        public ushort Field2A { get; set; }

        [TableMember]
        public ushort Field2C { get; set; }

        [TableMember]
        public ushort Field2E { get; set; }

        [TableMember]
        public ushort Field30 { get; set; }

        [TableMember]
        public ushort Field32 { get; set; }

        [TableMember]
        public ushort Field34 { get; set; }

        [TableMember]
        public ushort Field36 { get; set; }

        [TableMember]
        public ushort Field38 { get; set; }

        [TableMember]
        public ushort AttackDamage { get; set; }

        [TableMember]
        public ushort Field3C { get; set; }
    }
}