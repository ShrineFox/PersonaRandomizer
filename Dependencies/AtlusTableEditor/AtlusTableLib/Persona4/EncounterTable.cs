using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_ENCOUNT)]
    public class EncounterTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = ENCOUNTER_COUNT)]
        public Encounter[] Encounters { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment2 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment4 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment5 { get; set; }
    }
}
