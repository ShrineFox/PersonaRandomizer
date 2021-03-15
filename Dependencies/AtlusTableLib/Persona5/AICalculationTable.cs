using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    [Table(Game.Persona5PS3JP, Game.Persona5PS3NA, Game.Persona5PS3EU, Game.Persona5PS4JP, Game.Persona5PS4NA, Game.Persona5PS4EU, Name = TABLE_NAME_ENCOUNT)]
    public class AICalculationTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = UNIT_COUNT)]
        public ElsAISegment1Entry[] Segment1 { get; set; }
    }
}
