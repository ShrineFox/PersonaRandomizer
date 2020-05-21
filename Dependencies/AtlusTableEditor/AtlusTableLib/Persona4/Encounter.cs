using AtlusTableLib.Serialization;
using TGELib.IO;

namespace AtlusTableLib.Persona4
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

        [TableMember(FixedArrayLength = Constants.ENCOUNTER_MAX_UNITS)]
        public ushort[] UnitIds { get; set; }

        [TableMember]
        public ushort FieldId { get; set; }

        [TableMember]
        public ushort RoomId { get; set; }

        [TableMember]
        public ushort MusicId { get; set; }
    }
}
