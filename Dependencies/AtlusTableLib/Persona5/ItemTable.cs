using AtlusTableLib.Serialization;
using static AtlusTableLib.Persona5.Constants;

namespace AtlusTableLib.Persona5
{
    [Table(Game.Persona5PS3JP, Game.Persona5PS3NA, Game.Persona5PS3EU, Game.Persona5PS4JP, Game.Persona5PS4NA, Game.Persona5PS4EU, Name = TABLE_NAME_ITEM)]
    public class ItemTable
    {
        

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_ACCESSORY_COUNT)]
        public Accessory[] Accessories { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_ARMOR_COUNT)]
        public Armor[] Protectors { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_CONSUMABLE_COUNT)]
        public Consumable[] Consumables { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_KEYITEM_COUNT)]
        public KeyItem[] KeyItems { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_MATERIAL_COUNT)]
        public Material[] Materials { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_MELEEWEAPON_COUNT)]
        public MeleeWeapon[] MeleeWeapons { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_OUTFIT_COUNT)]
        public Outfit[] Outfits { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_SKILLCARD_COUNT)]
        public SkillCard[] SkillCards { get; set; }

        //[TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_TREASURE_COUNT)]
        //public Treasure[] Treasures { get; set; }

        [TableMember(TableMemberType.Segment, FixedArrayLength = ITEM_RANGEDWEAPON_COUNT)]
        public RangedWeapon[] RangedWeapons { get; set; }

        [TableMember(TableMemberType.Segment)]
        public byte[] Segment { get; set; }
    }
}
