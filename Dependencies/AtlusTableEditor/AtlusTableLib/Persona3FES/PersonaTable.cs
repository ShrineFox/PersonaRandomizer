using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_PERSONA)]
    public class PersonaTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.PERSONA_COUNT)]
        public PersonaStats[] PersonaStats { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.PERSONA_COUNT)]
        public PersonaSkillSet[] PersonaSkillSets { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment4 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment5 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment6 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment7 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment8 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment9 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment10 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment11 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment12 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment13 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment14 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment15 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment16 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment17 { get; set; }
    }
}
