using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
	public class BaneOfTheLand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bane of the Land");
			Tooltip.SetDefault("It shreds grass and people.");
		}

		public override void SetDefaults()
		{
			item.damage = 25; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 64; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 6; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true;
			item.knockBack = 8; 
			item.value = 1000000; 
			item.rare = ItemRarityID.Green; 
			item.UseSound = SoundID.Item11;
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 1; 
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet; 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 50);
			recipe.AddIngredient(ItemID.Cactus, 200);
			recipe.AddIngredient(ItemID.SoulofMight, 50);
			recipe.AddIngredient(ItemID.SoulofSight, 50);
			recipe.AddIngredient(ItemID.SoulofFright, 50);
			recipe.AddIngredient(ItemID.SoulofNight, 50);
			recipe.AddIngredient(ItemID.Megashark);
			recipe.AddIngredient(ItemID.Uzi);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .40f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, -10);
		}
	}
}