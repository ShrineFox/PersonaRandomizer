using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_MSG)]
    public class MessageTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = ARCANA_COUNT, FixedStringLength = ARCANA_MAX_STRING_LENGTH)]
        public string[] ArcanaNames { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = SKILL_COUNT, FixedStringLength = SKILL_MAX_STRING_LENGTH)]
        public string[] SkillNames { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = UNIT_COUNT, FixedStringLength = UNIT_MAX_STRING_LENGTH)]
        public string[] UnitNames { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT, FixedStringLength = PERSONA_MAX_STRING_LENGTH)]
        public string[] PersonaNames { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] BattleMessageData { get; set; }
    }
}
