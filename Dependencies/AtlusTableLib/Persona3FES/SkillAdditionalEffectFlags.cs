using System;

namespace AtlusTableLib.Persona3FES
{
    [Flags]
    public enum SkillAdditionalEffectFlags : ushort
    {
        Knockdown = 1 << 4
    }
}
