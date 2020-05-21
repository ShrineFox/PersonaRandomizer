using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_ENCOUNT_F)]
    public class EncounterTableF
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = Constants.ENCOUNTER_COUNT)]
        public Encounter[] Encounters { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] TableSegment2 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] TableSegment3 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] TableSegment4 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] TableSegment5 { get; set; }
    }
}
