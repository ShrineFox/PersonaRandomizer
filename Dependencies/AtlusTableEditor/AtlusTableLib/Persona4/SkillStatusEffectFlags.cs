using System;

namespace AtlusTableLib.Persona4
{
    [Flags]
    public enum SkillStatusEffectFlags : ushort
    {
        None = 1 << 0,
        AttackUp = 1 << 1,
        AttackDown = 1 << 2,
        AttackDoubled = 1 << 3,
        MagicAttackDoubled = 1 << 4,
        NullifyStatBonuses = 1 << 5,
        NullifyStatPenalties = 1 << 6,
        CriticalRateUp = 1 << 7,
        CriticalRateGreatlyUp = 1 << 8,
        ReflectPhysical = 1 << 9,
        ReflectMagical = 1 << 10,
        NullifyFireResistance = 1 << 11,
        NullifyIceResistance = 1 << 12,
        NullifyWindResistance = 1 << 13,
        NullifyElecResitance = 1 << 14,
        Unhittable = 1 << 15 // attack wont connect
    }
}
