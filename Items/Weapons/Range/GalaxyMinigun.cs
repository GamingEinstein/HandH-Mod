using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class GalaxyMinigun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Minigun");
            Tooltip.SetDefault("The light of the stars twinkle in this gun.");
        }

        public override void SetDefaults()
        {
            item.damage = 40; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.ranged = true; // sets the damage type to ranged
            item.width = 100; // hitbox width of the item
            item.height = 88; // hitbox height of the item
            item.useTime = 2; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 1000000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true; // if you can hold click to automatically use it again
            item.shoot = ProjectileID.UFOLaser;
            item.shootSpeed = 50f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 20);
            recipe.AddIngredient(ItemID.ShroomiteBar, 8);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(ItemID.MeteoriteBar, 8);
            recipe.AddIngredient(ItemID.SoulofFlight, 3);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Materials.MartianOrb>()); ;
            recipe.AddIngredient(ModContent.ItemType<GalaxyTwinkle>()); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, -10);
        }
    }
}