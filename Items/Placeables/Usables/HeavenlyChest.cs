using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Placeables.Usables
{
	public class HeavenlyChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heavenly Chest");
			Tooltip.SetDefault("Loot from the heavens.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 500;
			item.createTile = ModContent.TileType<Tiles.HeavenlyChest>();
		}
	}
}
