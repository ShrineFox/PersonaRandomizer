using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_AICALC)]
    public class AICalculationTable
    {
        [TableMember(TableMemberType.Segment)]
        public float[] Segment1 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public float[] Segment2 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public float[] Segment3 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment4 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public short[] Segment5 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment6 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment7 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment8 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment10 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public short[] Segment11 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public short[] Segment12 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public short[] Segment13 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public float[] Segment14 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment15 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public short[] Segment16 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment17 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] PlayerAIScript { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] BossAIScript { get; set; }
    }
}
