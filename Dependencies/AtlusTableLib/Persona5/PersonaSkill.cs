using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona5
{
    public struct PersonaSkill
    {
        [TableMember]
        public byte PendingLevels { get; set; }

        [TableMember]
        public byte Learnable { get; set; }

        [TableMember]
        public ushort SkillId { get; set; }
    }
}
