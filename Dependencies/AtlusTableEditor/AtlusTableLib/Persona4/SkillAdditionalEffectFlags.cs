using System;

namespace AtlusTableLib.Persona4
{
    [Flags]
    public enum SkillAdditionalEffectFlags : ushort
    {
        Knockdown = 1 << 4
    }
}
