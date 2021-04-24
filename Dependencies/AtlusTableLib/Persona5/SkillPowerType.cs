namespace AtlusTableLib.Persona5
{
    public enum SkillPowerType : byte
    {
        None = 0, // attack always misses
        NormalDamage,
        FakeDamage,
        DepleteHealthDamage, // reduces health to 1 but won't kill
        ConstantValueDamage,
        ConstantValueRestore,
        UnknownDamage6,
        UnknownRestore7,
        CurrentHpPercentageDamage,
        CurrentHpPercentageRestore,
        TotalHpPercentageDamage,
        TotalHpPercentageRestore,
        UnknownDamage12,
        UnknownDamage13,
        UnknownDamage14,
        UnknownRestore15,
        UnknownDamage16
        // values beyond these behave equal to None
    }
}
