using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class FinShredder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fin Shredder");
            Tooltip.SetDefault("Woah, a shaaaaark");
        }

        public override void SetDefaults()
        {
            item.damage = 10; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.ranged = true; // sets the damage type to ranged
            item.width = 50; // hitbox width of the item
            item.height = 34; // hitbox height of the item
            item.useTime = 10; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 10; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 1000000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true; // if you can hold click to automatically use it again
            item.shoot = ProjectileID.Shuriken;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Minishark);
            recipe.AddIngredient(ItemID.ArmoredCavefish);
            recipe.AddIngredient(ItemID.TissueSample, 7);
            recipe.AddIngredient(ItemID.ShadowScale, 7);
            recipe.AddIngredient(ItemID.Diamond, 3);
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
