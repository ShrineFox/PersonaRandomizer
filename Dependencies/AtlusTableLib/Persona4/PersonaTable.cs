using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_PERSONA)]
    public class PersonaTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT)]
        public PersonaStats[] PersonaInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT)]
        public PersonaSkillSet[] PersonaSkillSets { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment4 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment5 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment6 { get; set; }
    }
}
