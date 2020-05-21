using System;
using System.Collections.Generic;
using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_SKILL)]
    public class UnitTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.UNIT_COUNT)]
        public UnitStats[] Units { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment2 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment3 { get; set; }
    }
}
