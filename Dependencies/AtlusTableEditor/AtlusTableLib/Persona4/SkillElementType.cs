namespace AtlusTableLib.Persona4
{
    public enum SkillElementType : ushort
    {
        // Primary elements
        Physical = 0,
        Fire,
        Ice,
        Electricity,
        Wind,
        Almighty,
        Light,
        Dark,

        // Ailment damage type elements
        Confusion,
        Poison,
        Fear,
        Rage,
        Unknown12,
        Exhaustion,
        Enervation,
        Silence,

        // Misc non-elements
        Restoration,
        StatusEffect,
        Navigator,

        // Ailments
        Ailment           = 0xFF,
        DarkAilment       = (Dark << 8)       | Ailment,
        ConfusionAilment  = (Confusion << 8)  | Ailment,
        PoisonAilment     = (Poison << 8)     | Ailment,
        FearAilment       = (Fear << 8)       | Ailment,
        RageAilment       = (Rage << 8)       | Ailment,
        ExhaustionAilment = (Exhaustion << 8) | Ailment,
        EnervationAilment = (Enervation << 8) | Ailment,
        SilenceAilment    = (Silence << 8)    | Ailment,

        // Misc non-elements
        Affinity = 0xFF01,
        NonElemental = 0xFFFF
    }
}
