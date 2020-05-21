using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
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
