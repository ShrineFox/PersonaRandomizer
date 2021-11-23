using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct ElsAISegment2Entry
    {
        [TableMember(FixedArrayLength = 160)]
        public ushort[] Data { get; set; }
    }
}