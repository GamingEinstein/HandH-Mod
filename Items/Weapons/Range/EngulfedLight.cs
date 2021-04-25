using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class EngulfedLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Engulfed Light");
            Tooltip.SetDefault("Stripey boi");
        }

        public override void SetDefaults()
        {
            item.damage = 920; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.ranged = true; // sets the damage type to ranged
            item.width = 40; // hitbox width of the item
            item.height = 16; // hitbox height of the item
            item.useTime = 6; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 6; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 1000000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true; // if you can hold click to automatically use it again
            item.shoot = ProjectileID.LaserMachinegunLaser;
            item.shootSpeed = 20f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 10 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeables.OreBars.BlissFire.BlissFireBar>(), 25); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.Blazzzterr6000>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.BaneOfTheLand>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.GalaxyMinigun>()); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
