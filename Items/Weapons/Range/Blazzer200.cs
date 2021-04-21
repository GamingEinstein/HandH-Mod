using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class Blazzer200 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazzer 200");
            Tooltip.SetDefault("Gun is Fun fun fun!");
        }

        public override void SetDefaults()
        {
            item.damage = 30; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.ranged = true; // sets the damage type to ranged
            item.width = 40; // hitbox width of the item
            item.height = 32; // hitbox height of the item
            item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 1000000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true; // if you can hold click to automatically use it again
            item.shoot = ProjectileID.Shuriken;
            item.shootSpeed = 2f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Minishark);
            recipe.AddIngredient(ItemID.Musket);
            recipe.AddIngredient(ItemID.TheUndertaker);
            recipe.AddIngredient(ItemID.TissueSample, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 20);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, -10);
        }
    }
}
