using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5Royal.Constants;

namespace AtlusTableLib.Persona5Royal
{
    public enum ItemType : uint
    {
        Dagger = 1,
        Crowbar = 2,
        Whip = 4,
        BanditSword = 8,
        Katana = 16,
        FistWeapons = 32,
        Axe = 64,
        BeamSword = 128,
        Unknown = 256,
        Unknown2 = 512,
        Handgun = 1024,
        Shotgun = 2048,
        SMG = 4096,
        Slingshot = 8192,
        AR = 16384,
        Revolver = 32768,
        GrenadeLauncher = 65536,
        ToyGun = 131072,
        Unknown3 = 262144,
        Unknown4 = 524288,
        Armor = 1048576,
        Accessory = 2097152,
        Consumable = 4194304,
        KeyItem = 8388608,
        Treasure = 16777216,
        SkillCard = 33554432,
        Outfit = 67108864,
        DungeonItem = 134217728,
        Material = 268435456,
        Gift = 536870912,
        Unknown5 = 1073741824,
        Unknown6 = 2147483648
    }

    public struct Accessory
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Users { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public byte StrengthBonus { get; set; }

        [TableMember]
        public byte MagicBonus { get; set; }

        [TableMember]
        public byte EnduranceBonus { get; set; }

        [TableMember]
        public byte AgilityBonus { get; set; }

        [TableMember]
        public byte LuckBonus { get; set; }

        [TableMember]
        public byte Field15 { get; set; }

        [TableMember]
        public ushort Effect { get; set; }

        [TableMember]
        public ushort Field18 { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort StrengthBonusPower { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field34 { get; set; }

        [TableMember]
        public ushort Field36 { get; set; }

        [TableMember]
        public ushort Field38 { get; set; }

        [TableMember]
        public ushort Field3A { get; set; }

        [TableMember]
        public ushort Field3C { get; set; }

        [TableMember]
        public ushort Field3E { get; set; }

        [TableMember]
        public ushort Field40 { get; set; }

        [TableMember]
        public ushort Field42 { get; set; }

        [TableMember]
        public ushort Field44 { get; set; }

        [TableMember]
        public ushort Field46 { get; set; }

        [TableMember]
        public ushort Field48 { get; set; }
    }

    public struct Armor
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Users { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Defense { get; set; }

        [TableMember]
        public ushort Evasion { get; set; }

        [TableMember]
        public byte Strength { get; set; }

        [TableMember]
        public byte Magic { get; set; }

        [TableMember]
        public byte Endurance { get; set; }

        [TableMember]
        public byte Agility { get; set; }

        [TableMember]
        public byte Luck { get; set; }

        [TableMember]
        public byte Field23 { get; set; }

        [TableMember]
        public ushort Effect { get; set; }

        [TableMember]
        public ushort Field18 { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field34 { get; set; }
    }

    public struct Consumable
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Field08 { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort SkillId { get; set; }

        [TableMember]
        public ushort Field0E { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember]
        public ushort Field24 { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public ushort Field28 { get; set; }

        [TableMember]
        public ushort Field2A { get; set; }

        [TableMember]
        public ushort Field2C { get; set; }

        [TableMember]
        public ushort Field2E { get; set; }
    }

    public struct KeyItem
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Field08 { get; set; }
    }

    public struct Material
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Field08 { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public ushort Field0E { get; set; }

        [TableMember]
        public ushort Field10 { get; set; }

        [TableMember]
        public ushort Field12 { get; set; }

        [TableMember]
        public ushort Field14 { get; set; }

        [TableMember]
        public ushort Field16 { get; set; }

        [TableMember]
        public ushort Field18 { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }
    }

    public struct MeleeWeapon
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Users { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public ushort Attack { get; set; }

        [TableMember]
        public ushort Accuracy { get; set; }

        [TableMember]
        public byte Strength { get; set; }

        [TableMember]
        public byte Magic { get; set; }

        [TableMember]
        public byte Endurance { get; set; }

        [TableMember]
        public byte Agility { get; set; }

        [TableMember]
        public byte Luck { get; set; }

        [TableMember]
        public byte Field17 { get; set; }

        [TableMember]
        public ushort Effect { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember]
        public ushort Field24 { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field3C { get; set; }
    }

    public struct Outfit
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Users { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public ushort Field0E { get; set; }

        [TableMember]
        public ushort Field10 { get; set; }

        [TableMember]
        public ushort Field12 { get; set; }

        [TableMember]
        public ushort Field14 { get; set; }

        [TableMember]
        public ushort Field16 { get; set; }

        [TableMember]
        public ushort Field18 { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }
    }

    public struct SkillCard
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort SkillId { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public ushort Field0E { get; set; }

        [TableMember]
        public ushort Field10 { get; set; }

        [TableMember]
        public ushort Field12 { get; set; }

        [TableMember]
        public ushort Field14 { get; set; }
    }

    public struct Treasure
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Field08 { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public ushort Field0E { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field1A { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember]
        public ushort Field24 { get; set; }

        [TableMember]
        public ushort Field26 { get; set; }

        [TableMember]
        public ushort Field28 { get; set; }

        [TableMember]
        public ushort Field2A { get; set; }

        [TableMember]
        public ushort Field2C { get; set; }

        [TableMember]
        public ushort Field2E { get; set; }
    }

    public struct RangedWeapon
    {
        [TableMember]
        public ItemType Type { get; set; }

        [TableMember]
        public ushort Field02 { get; set; }

        [TableMember]
        public ushort Field04 { get; set; }

        [TableMember]
        public ushort Field06 { get; set; }

        [TableMember]
        public ushort Users { get; set; }

        [TableMember]
        public ushort Field0A { get; set; }

        [TableMember]
        public ushort Field0C { get; set; }

        [TableMember]
        public ushort Attack { get; set; }

        [TableMember]
        public ushort Accuracy { get; set; }

        [TableMember]
        public ushort Rounds { get; set; }

        [TableMember]
        public byte Strength { get; set; }

        [TableMember]
        public byte Magic { get; set; }

        [TableMember]
        public byte Endurance { get; set; }

        [TableMember]
        public byte Agility { get; set; }

        [TableMember]
        public byte Luck { get; set; }

        [TableMember]
        public byte Field19 { get; set; }

        [TableMember]
        public ushort Effect { get; set; }

        [TableMember]
        public ushort Field1C { get; set; }

        [TableMember]
        public ushort Field1E { get; set; }

        [TableMember]
        public ushort Field20 { get; set; }

        [TableMember]
        public ushort Field22 { get; set; }

        [TableMember]
        public ushort Field24 { get; set; }

        [TableMember]
        public int Price { get; set; }

        [TableMember]
        public int Value { get; set; }

        [TableMember]
        public byte MonthAvailable { get; set; }

        [TableMember]
        public byte DayAvailable { get; set; }

        [TableMember]
        public ushort Field38 { get; set; }
    }
}
