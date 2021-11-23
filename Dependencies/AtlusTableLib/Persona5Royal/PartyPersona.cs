using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct PartyPersona
    {
        [TableMember]
        public ushort PartyMember { get; set; }

        [TableMember]
        public byte LevelsAvailable { get; set; }

        [TableMember]
        public byte Field03 { get; set; }

        [TableMember(FixedArrayLength = PERSONA_PARTY_MAX_SKILL)]
        public PersonaSkill[] Skills {get; set;}

        [TableMember(FixedArrayLength = 98)]
        public Stats[] StatGain { get; set; }
    }
}
