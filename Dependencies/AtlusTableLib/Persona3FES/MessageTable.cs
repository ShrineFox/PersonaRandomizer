using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESNA, Name = Constants.TABLE_NAME_MSG)]
    public class MessageTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.ARCANA_COUNT, FixedStringLength = Constants.ARCANA_MAX_STRING_LENGTH)]
        public string[] ArcanaNames { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.SKILL_COUNT, FixedStringLength = Constants.SKILL_MAX_STRING_LENGTH)]
        public string[] SkillNames { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.UNIT_COUNT, FixedStringLength = Constants.UNIT_MAX_STRING_LENGTH)]
        public string[] UnitNames { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.PERSONA_COUNT, FixedStringLength = Constants.PERSONA_MAX_STRING_LENGTH)]
        public string[] PersonaNames { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] BattleMessageScript { get; set; }
    }
}
