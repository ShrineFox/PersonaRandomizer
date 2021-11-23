using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct PersonaSkillSet
    {
        [TableMember]
        public Stats WeightedStatDistribution { get; set; }

        [TableMember]
        public byte Field05 { get; set; }

        [TableMember(FixedArrayLength = PERSONA_MAX_SKILL)]
        public PersonaSkill[] Skills { get; internal set; }
    }
}
