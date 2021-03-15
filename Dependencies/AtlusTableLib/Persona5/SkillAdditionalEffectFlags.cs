using System;

namespace AtlusTableLib.Persona5
{
    [Flags]
    public enum SkillAdditionalEffectFlags : ushort
    {
        Knockdown = 1 << 4
    }
}
