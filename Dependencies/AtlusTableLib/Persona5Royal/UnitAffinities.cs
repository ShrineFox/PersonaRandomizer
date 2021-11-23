using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct UnitAffinities
    {
        [TableMember(FixedArrayLength = 20)]
        public AffinityFlags[] AffinityFlags { get; set; }
    }
}
