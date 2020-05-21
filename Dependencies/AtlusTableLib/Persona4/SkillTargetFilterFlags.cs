using System;

namespace AtlusTableLib.Persona4
{
    [Flags]
    public enum SkillTargetFilterFlags : byte
    {
        None = 1 << 0,
        Enemies = 1 << 1,
        Allies = 1 << 2,
        Self = 1 << 3
    }
}
