﻿using AtlusTableLib.Serialization;

namespace AtlusTableLib.Persona3FES
{
    [Table(Game.Persona3FESJP, Game.Persona3FESNA, Game.Persona3FESEU, Name = Constants.TABLE_NAME_ENCOUNT)]
    public class EncounterTable
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
