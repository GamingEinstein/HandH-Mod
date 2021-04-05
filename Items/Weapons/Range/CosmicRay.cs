using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
	public class CosmicRay : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Ray");
			Tooltip.SetDefault("It radiates energy of the stars.");
		}

		public override void SetDefaults()
		{
			item.damage = 80; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 100; // hitbox width of the item
			item.height = 88; // hitbox height of the item
			item.useTime = 10; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true;
			item.knockBack = 10;
			item.value = 1000000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ProjectileID.UFOLaser;
			item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Bullet;
		}
	}
}
