namespace AtlusTableLib.Persona5
{
    public enum SkillElementType : ushort
    {
        // Primary elements
        Physical = 0,
        Gun,
        Fire,
        Ice,
        Electricity,
        Wind,
        Almighty,
        Bless,
        Curse,
        Psychokinesis,
        Nuclear,

        // Ailment damage type elements
        Dizzy,
        Forget,
        Sleep,
        Confuse,
        Fear,
        Despair,
        Rage,
        Brainwash,
        Hunger,

        // Misc non-elements
        Restoration,
        StatusEffect,
        Navigator,

        // Ailments
        Ailment          = 0xFF,
        DizzyAilment     = (Dizzy << 8)     | Ailment,
        ForgetAilment    = (Forget << 8)    | Ailment,
        SleepAilment     = (Sleep << 8)     | Ailment,
        ConfuseAilment   = (Confuse << 8)   | Ailment,
        FearAilment      = (Fear << 8)      | Ailment,
        DespairAilment   = (Despair << 8)   | Ailment,
        RageAilment      = (Rage << 8)      | Ailment,
        BrainwashAilment = (Brainwash << 8) | Ailment,
        HungerAilment    = (Hunger << 8)    | Ailment,

        // Misc non-elements
        Affinity = 0xFF01,
        NonElemental = 0xFFFF
    }
}
