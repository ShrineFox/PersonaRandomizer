using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    public struct UnitAffinities
    {
        [TableMember(FixedArrayLength = 20)]
        public AffinityFlags[] AffinityFlags { get; set; }
    }
}
