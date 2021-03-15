using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    [Table(Game.Persona5PS3JP, Game.Persona5PS3NA, Game.Persona5PS3EU, Game.Persona5PS4JP, Game.Persona5PS4NA, Game.Persona5PS4EU, Name = TABLE_NAME_PERSONA)]
    public class PersonaTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT)]
        public PersonaStats[] PersonaInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT)]
        public PersonaSkillSet[] PersonaSkillSets { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = 49)]
        public PartyPersona[] PartyPersonas { get; set; }
    }
}
