using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_MODEL)]
    public class ModelTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = PARTY_COUNT)]
        public PartyModelInfo[] PartyModelInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = UNIT_COUNT)]
        public UnitModelInfo[] UnitModelInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT)]
        public PersonaModelInfo[] PersonaModelInfo { get; set; }
    }
}
