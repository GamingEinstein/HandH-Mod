using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
	public class LakeSpiritFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lake Spirit Fragment");
			Tooltip.SetDefault("A fragment of the spirit of the lake");
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