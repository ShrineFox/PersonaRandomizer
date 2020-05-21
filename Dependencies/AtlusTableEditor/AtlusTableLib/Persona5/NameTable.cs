using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    [Table(Game.Persona5PS3JP, Game.Persona5PS3NA, Game.Persona5PS3EU, Game.Persona5PS4JP, Game.Persona5PS4NA, Game.Persona5PS4EU, Name = TABLE_NAME_NAME)]
    public class NameTable
    {
        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] ArcanaNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] SkillNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] UnitNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] PersonaNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] AccessoryNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] ArmorNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] ConsumableItemNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] KeyItemNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] MaterialNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] MeleeWeaponNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] BattleActionNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] OutfitNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] SkillCardNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] ConfidantNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] PartyMemberLastNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] PartyMemberFirstNames { get; set; }

        [TableMember(TableMemberType.VariableLengthStringSegmentPair)]
        public string[] RangedWeaponNames { get; set; }
    }
}
