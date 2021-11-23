using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct UnitStats
    {
        [TableMember]
        public byte Field00 { get; set; }

        [TableMember]
        public byte Field01 { get; set; }

        [TableMember]
        public byte Arcana { get; set; }

        [TableMember]
        public byte Field03 { get; set; }

        [TableMember]
        public byte Field04 { get; set; }

        [TableMember]
        public byte Level { get; set; }

        [TableMember]
        public byte Field06 { get; set; }

        [TableMember]
        public byte Field07 { get; set; }

        [TableMember]
        public int Hp { get; set; }

        [TableMember]
        public int Sp { get; set; }

        [TableMember]
        public Stats Stats { get; set; }

        [TableMember]
        public byte Field15 { get; set; }

        [TableMember(FixedArrayLength = UNIT_MAX_SKILL)]
        public ushort[] SkillIDs { get; set; }

        [TableMember]
        public ushort ExpReward { get; set; }

        [TableMember]
        public ushort MoneyReward { get; set; }

        [TableMember]
        public byte Field2A { get; set; }

        [TableMember]
        public byte Field2B { get; set; }

        [TableMember]
        public byte Field2C { get; set; }

        [TableMember]
        public byte Field2D { get; set; }

        [TableMember]
        public byte Field2E { get; set; }

        [TableMember]
        public byte Field2F { get; set; }

        [TableMember]
        public byte Field30 { get; set; }

        [TableMember]
        public byte Field31 { get; set; }

        [TableMember]
        public byte Field32 { get; set; }

        [TableMember]
        public byte Field33 { get; set; }

        [TableMember]
        public byte Field34 { get; set; }

        [TableMember]
        public byte Field35 { get; set; }

        [TableMember]
        public byte Field36 { get; set; }

        [TableMember]
        public byte Field37 { get; set; }

        [TableMember]
        public byte Field38 { get; set; }

        [TableMember]
        public byte Field39 { get; set; }

        [TableMember]
        public byte Field3A { get; set; }

        [TableMember]
        public byte Field3B { get; set; }

        [TableMember]
        public byte Field3C { get; set; }

        [TableMember]
        public byte Field3D { get; set; }

        [TableMember]
        public byte Field3E { get; set; }

        [TableMember]
        public byte Field3F { get; set; }

        [TableMember]
        public ushort AttackAccuracy { get; set; }

        [TableMember]
        public ushort AttackDamage { get; set; }
    }
}