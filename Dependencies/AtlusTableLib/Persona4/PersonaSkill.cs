using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona4
{
    public struct PersonaSkill
    {
        [TableMember]
        public byte PendingLevels { get; set; }

        [TableMember]
        public byte Field01 { get; set; }

        [TableMember]
        public ushort SkillId { get; set; }
    }
}
