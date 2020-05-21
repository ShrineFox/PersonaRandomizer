using AtlusTableLib.Persona4;
using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona4Golden
{
    [Table(Game.Persona4GoldenJP, Game.Persona4GoldenNA, Game.Persona4GoldenEU, Name = "SKILL")]
    public class SkillTable
    {
        [TableMember(FixedArrayLength = 624)]
        public SkillElementType[] SkillElementTypes { get; set; }

        [TableMember(FixedArrayLength = 472)]
        public Skill[] Skills { get; set; }
    }
}
