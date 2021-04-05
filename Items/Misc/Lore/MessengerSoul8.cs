using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
	public class Jungle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle");
			Tooltip.SetDefault("This muddy place has an atmosphere that tells me that there is more to these overgrown woods than i thought...");
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
