using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    public struct PersonaSkillSet
    {
        [TableMember]
        public ushort Field00 { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember(FixedArrayLength = PERSONA_MAX_SKILL)]
        public PersonaSkill[] Skills { get; internal set; }
    }
}
