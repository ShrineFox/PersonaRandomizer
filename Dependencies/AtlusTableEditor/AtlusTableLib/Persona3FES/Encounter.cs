using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    public class Encounter
    {
        [TableMember]
        public ushort EncounterFlags { get; set; }

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

        [TableMember]
        public ushort Field18 { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }
    }
}
