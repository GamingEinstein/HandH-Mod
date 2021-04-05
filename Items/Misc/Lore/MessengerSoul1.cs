using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Heaven : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven");
			Tooltip.SetDefault("This place was once so grand, now it is nothing but a shell of its former self after the great crumble...");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(gold: 0);
			item.rare = ItemRarityID.Cyan;
			item.maxStack = 1;
		}
	}
}
