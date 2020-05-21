using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_MODEL)]
    public class ModelTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.PARTY_COUNT)]
        public PartyModelInfo[] PartyModelInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.PARTY2_COUNT)]
        public Party2ModelInfo[] Party2ModelInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.UNIT_COUNT)]
        public UnitModelInfo[] UnitModelInfo { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.PERSONA_COUNT)]
        public PersonaModelInfo[] PersonaModelInfo { get; set; }
    }
}
