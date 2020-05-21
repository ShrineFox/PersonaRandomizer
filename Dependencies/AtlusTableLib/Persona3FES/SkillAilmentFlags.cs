using System;

namespace AtlusTableLib.Persona3FES
{
    [Flags]
    public enum SkillAilmentFlags : ushort
    {
        None = 1 << 0,
        Dizzy = 1 << 1,
        Enrage = 1 << 2,
        Fear = 1 << 3,
        Silence = 1 << 4,
        Confusion = 1 << 5,
        Poison = 1 << 6,
        Exhaustion = 1 << 7,
        Enervation = 1 << 8,
        Hypnotized = 1 << 9 // like in the boss fight, converts an ally to fight against you
    }
}
