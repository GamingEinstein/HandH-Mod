using HandHmod.Items;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;

namespace HandHmod.Items.Accessories.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class HeavenFlameWings : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return !GetInstance<HandHmodConfigServer>().DisableExampleWings;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven Flame Wings");
			Tooltip.SetDefault("Wings of the former heavens");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 18000;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 30f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<HeavenFlameBar>(), 90);
			recipe.AddIngredient(ItemType<HellFireBar>(), 30);
			recipe.AddIngredient(ItemID.SoulofFlight);
			recipe.AddIngredient(ItemID.WingsNebula);
			recipe.AddIngredient(ItemID.WingsSolar);
			recipe.AddIngredient(ItemID.WingsVortex);
			recipe.AddIngredient(ItemID.WingsStardust);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
