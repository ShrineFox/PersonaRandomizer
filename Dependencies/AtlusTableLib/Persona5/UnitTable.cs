using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    [Table(Game.Persona5PS3JP, Game.Persona5PS3NA, Game.Persona5PS3EU, Game.Persona5PS4JP, Game.Persona5PS4NA, Game.Persona5PS4EU, Name = TABLE_NAME_UNIT)]
    public class UnitTable
    {
        [TableMember(TableMemberType.Segment, FixedArrayLength = UNIT_COUNT)]
        public UnitStats[] Units { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = UNIT_COUNT)]
        public UnitAffinities[] Affinities { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = PERSONA_COUNT)]
        public UnitAffinities[] PersonaAffinities { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment4 { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment5 { get; set; }
    }
}
