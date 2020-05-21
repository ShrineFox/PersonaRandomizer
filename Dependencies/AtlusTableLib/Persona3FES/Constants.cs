using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlusTableLib.Persona3FES
{
    public static class Constants
    {
        public const string TABLE_NAME_AICALC = "AICALC";
        public const string TABLE_NAME_AILCALC_F = "AICALC_F";
        public const string TABLE_NAME_EFFECT = "EFFECT";
        public const string TABLE_NAME_ENCOUNT = "ENCOUNT";
        public const string TABLE_NAME_ENCOUNT_F = "ENCOUNT_F";
        public const string TABLE_NAME_MODEL = "MODEL";
        public const string TABLE_NAME_MSG = "MSG";
        public const string TABLE_NAME_PERSONA = "PERSONA";
        public const string TABLE_NAME_PERSONA_F = "PERSONA_F";
        public const string TABLE_NAME_SKILL = "SKILL";
        public const string TABLE_NAME_SKILL_F = "SKILL_F";
        public const string TABLE_NAME_UNIT = "UNIT";
        public const string TABLE_NAME_UNIT_F = "UNIT_F";

        public const int ENCOUNTER_COUNT = 1024;
        public const int ENCOUNTER_MAX_UNITS = 5;

        public const int ARCANA_COUNT = 32;
        public const int ARCANA_MAX_STRING_LENGTH = 20;

        public const int SKILL_COUNT = 624;
        public const int SKILL_COUNT_REAL = 464;
        public const int SKILL_MAX_STRING_LENGTH = 18;

        public const int UNIT_COUNT = 336;
        public const int UNIT_MAX_STRING_LENGTH = 18;
        public const int UNIT_MAX_ANIM = 19;
        public const int UNIT_MAX_SKILL = 8;

        public const int PERSONA_COUNT = 256;
        public const int PERSONA_MAX_STRING_LENGTH = 16;
        public const int PERSONA_MAX_ANIM = 6;
        public const int PERSONA_MAX_SKILL = 16;

        public const int PARTY_COUNT = 8;
        public const int PARTY_MAX_CRIT = 8;
        public const int PARTY_MAX_ASSIST = 8;
        public const int PARTY_MAX_ANIM = 26;

        public const int PARTY2_COUNT = 11;
        public const int PARTY2_MAX_ANIM = 23;
    }
}
