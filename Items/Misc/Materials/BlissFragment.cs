using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
	public class BlissFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bliss Fragment");
			Tooltip.SetDefault("The Fragments of a Heaven that once was");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(gold: 10);
			item.rare = ItemRarityID.Cyan;
			item.material = true;
			item.maxStack = 999;
		}
	}
}