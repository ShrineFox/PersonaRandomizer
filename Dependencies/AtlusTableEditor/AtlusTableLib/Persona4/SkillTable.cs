using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_SKILL)]
    public class SkillTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = SKILL_COUNT)]
        public SkillElementType[] SkillElementTypes { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = SKILL_COUNT_REAL)]
        public Skill[] Skills { get; set; }
    }
}
