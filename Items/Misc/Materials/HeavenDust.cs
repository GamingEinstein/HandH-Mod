using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
	public class HeavenDust : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heavenly Dust");
			Tooltip.SetDefault("Dust of the heavens");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(gold: 1);
			item.rare = ItemRarityID.Cyan;
			item.material = true;
			item.maxStack = 999;
		}
	}
}