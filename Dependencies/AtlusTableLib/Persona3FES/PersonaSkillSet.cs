using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    public struct PersonaSkillSet
    {
        [TableMember]
        public ushort Field00 { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember(FixedArrayLength = Constants.PERSONA_MAX_SKILL)]
        public PersonaSkill[] Skills { get; internal set; }
    }
}
