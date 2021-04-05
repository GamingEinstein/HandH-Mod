using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
	public class Infection : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Infection");
			Tooltip.SetDefault("A deadly infection began to spread after the Great Crumble, a virus rooted in the darkness of below...");
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
