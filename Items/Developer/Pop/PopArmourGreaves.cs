using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Developer.Pop
{
    [AutoloadEquip(EquipType.Legs)]
    public class PopArmourGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pop's Greaves");
            Tooltip.SetDefault("Perfect for impersonating a modder!");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 99);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }
    }
}