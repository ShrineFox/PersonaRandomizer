using System;
using System.Collections.Generic;
using System.Linq;
using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public struct SkillElement
    {
        [TableMember]
        public SkillElementType SkillElementType { get; set; }

        [TableMember]
        public byte Passive { get; set; }
    }
}
