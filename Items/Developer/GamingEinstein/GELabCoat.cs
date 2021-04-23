using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Developer.GamingEinstein
{
    [AutoloadEquip(EquipType.Body)]
    public class GELabCoat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GamingEinstein's Lab Coat");
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
