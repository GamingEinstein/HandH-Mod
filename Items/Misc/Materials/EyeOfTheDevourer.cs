using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
	public class EyeOfTheDevourer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Devourer");
			Tooltip.SetDefault("It radiates with a burning energy");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = Item.buyPrice(gold: 50);
			item.rare = ItemRarityID.Cyan;
			item.material = true;
			item.maxStack = 999;
		}
	}
}