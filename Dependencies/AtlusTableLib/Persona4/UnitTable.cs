using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_UNIT)]
    public class UnitTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = UNIT_COUNT)]
        public UnitStats[] Units { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment2 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }
    }
}
