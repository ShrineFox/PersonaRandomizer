using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona4.Constants;

namespace AtlusTableLib.Persona4
{
    [Table(Game.Persona4JP, Game.Persona4NA, Game.Persona4EU, Name = TABLE_NAME_AICALC)]
    public class AICalculationTable
    {
        [TableMember(TableMemberType.Segment)]
        public byte[] Segment1 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment2 { get; set; }

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
        public byte[] PlayerAIScript { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] EnemyAIScript { get; set; }
    }
}
