using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_SKILL)]
    public class SkillTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.SKILL_COUNT)]
        public SkillElementType[] SkillElementTypes { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.SKILL_COUNT_REAL)]
        public Skill[] Skills { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }
    }
}
