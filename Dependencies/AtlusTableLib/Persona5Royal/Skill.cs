using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct Skill
    {
        [TableMember]
        public byte CasterEffect1 { get; set; }
        
        [TableMember]
        public byte CasterEffect2 { get; set; }
        
        [TableMember]
        public byte AreaType { get; set; }
        
        [TableMember]
        public byte DamageStat { get; set; }
        
        [TableMember]
        public byte CostType { get; set; }

        [TableMember]
        public byte Field0A { get; set; }

        [TableMember]
        public byte Field0C { get; set; }

        [TableMember]
        public byte SkillCost { get; set; }
        
        [TableMember]
        public byte Field10 { get; set; }
        
        [TableMember]
        public byte PhysicalOrMagic { get; set; }

        [TableMember]
        public byte NumberOfTargets { get; set; }
        
        [TableMember]
        public byte Usable { get; set; }

        [TableMember]
        public byte TargetRestrictions { get; set; }
        
        [TableMember]
        public byte Field28 { get; set; }

        [TableMember]
        public byte Field2A { get; set; }
        
        [TableMember]
        public byte Field2C { get; set; }
        
        [TableMember]
        public byte Field2E { get; set; }

        [TableMember]
        public byte Field30 { get; set; }

        [TableMember]
        public byte Field32 { get; set; }

        [TableMember]
        public byte Field34 { get; set; }

        [TableMember]
        public byte Accuracy { get; set; }

        [TableMember]
        public byte MinHits { get; set; }

        [TableMember]
        public byte MaxHits { get; set; }

        [TableMember]
        public byte HPEffect { get; set; }

        [TableMember]
        public ushort BaseDamage { get; set; }

        [TableMember]
        public byte SPEffect { get; set; }
        
        [TableMember]
        public byte Field42 { get; set; }
        
        [TableMember]
        public byte Field44 { get; set; }
        
        [TableMember]
        public byte SPAmount { get; set; }
        
        [TableMember]
        public byte ApplyOrCureEffect { get; set; }

        [TableMember]
        public byte SecondaryEffectChance { get; set; }
        
        [TableMember]
        public byte Field4C { get; set; }
        
        [TableMember]
        public byte Effect1 { get; set; }

        [TableMember]
        public byte Effect2 { get; set; }

        [TableMember]
        public byte Effect3 { get; set; }

        [TableMember]
        public byte Effect4 { get; set; }
        
        [TableMember]
        public byte Effect5 { get; set; }

        [TableMember]
        public byte Effect6 { get; set; }

        [TableMember]
        public byte BuffDebuff { get; set; }
        
        [TableMember]
        public byte ExtraEffect { get; set; }

        [TableMember]
        public byte CritChance { get; set; }

        [TableMember]
        public byte Field60 { get; set; }

        [TableMember]
        public byte Field62 { get; set; }
    }
}