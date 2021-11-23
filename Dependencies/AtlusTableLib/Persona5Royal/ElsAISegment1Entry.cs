using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct ElsAISegment1Entry
    {
        [TableMember]
        public ushort Field00 { get; set; }

        [TableMember]
        public ushort AiId { get; set; }

        [TableMember(FixedArrayLength = 10)]
        public int[] Unknown { get; set; }
    }
}