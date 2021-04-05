using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
	public class HyperDeathBringer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hyper Death Bringer");
			Tooltip.SetDefault("A blade forged from the very essence of heaven and hell.");
		}

		public override void SetDefaults() 
		{
			item.damage = 6743;
			item.melee = true;
			item.width = 900;
			item.height = 900;
			item.useTime = 1;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6743;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarOre, 999);
			recipe.AddIngredient(ModContent.ItemType<HellFireBar>(), 999);
			 recipe.AddIngredient(ModContent.ItemType<HeavenFlameBar>(), 999);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}