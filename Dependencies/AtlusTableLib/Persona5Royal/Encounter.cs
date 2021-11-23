using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct Encounter
    {
        [TableMember]
        public ushort EncounterType { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember(FixedArrayLength = ENCOUNTER_MAX_UNITS)]
        public ushort[] UnitIDs { get; set; }

        [TableMember]
        public ushort FieldId { get; set; }

        [TableMember]
        public ushort RoomId { get; set; }

        [TableMember]
        public ushort MusicId { get; set; }
    }
}
