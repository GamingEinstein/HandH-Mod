using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Developer.Pop
{
    [AutoloadEquip(EquipType.Body)]
    public class PopArmourChestplate : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pop's Chestplate");
            Tooltip.SetDefault("Perfect for impersonating a modder!");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 999);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }
    }
}
