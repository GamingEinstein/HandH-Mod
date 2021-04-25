using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class TheDenizen : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Denizen");
            Tooltip.SetDefault("It smells of ash and tea"); //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 8;
            item.useAnimation = 8;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
            item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
            item.shoot = ProjectileID.DeathSickle;
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HeavenFlameBar>(), 6); ;
            recipe.AddIngredient(ModContent.ItemType<HeavenDust>(), 5); ;
            recipe.AddIngredient(ItemID.VenomBullet, 500);
            recipe.AddIngredient(ItemID.DeathSickle);
            recipe.AddIngredient(ItemID.IceSickle);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(ItemID.Bladetongue);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
            // 60 frames = 1 second
            target.AddBuff(BuffID.Venom, 60);
            target.AddBuff(BuffID.Ichor, 60);
            target.AddBuff(BuffID.Frostburn, 60);
        }

        // Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
        // See Source code for Star Wrath projectile to see how it passes through tiles.
        /*	The following changes to SetDefaults 
		 	item.shoot = 503;
			item.shootSpeed = 8f;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}*/
    }
}