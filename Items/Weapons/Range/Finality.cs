using HandHmod.Items.Misc.Materials;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class Finality : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Finality");
            Tooltip.SetDefault("The end of the journey has truly been reached. The ultimate gun is in you hands");
        }

        public override void SetDefaults()
        {
            item.damage = 30000; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            item.ranged = true; // sets the damage type to ranged
            item.width = 144; // hitbox width of the item
            item.height = 60; // hitbox height of the item
            item.useTime = 2; // The item's use time in ticks (60 ticks == 1 second.)
            item.useAnimation = 2; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 1000000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true; // if you can hold click to automatically use it again
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 60f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeables.OreBars.HeavenFlame.HeavenFlameBar>(), 95); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Placeables.OreBars.BlissFire.BlissFireBar>(), 95); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Placeables.OreBars.HellFireFrag.HellFireBar>(), 95); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.CosmicRay>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.GalaxyMinigun>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.Blazzzterr6000>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Range.DeathbringerBow>()); ;
            recipe.AddIngredient(ItemID.LunarBar, 95);
            recipe.AddIngredient(ItemID.SDMG);
            recipe.AddIngredient(ItemID.DaedalusStormbow);
            recipe.AddIngredient(ModContent.ItemType<BloodOfTheHeavenDemigod>(), 40); ;
            recipe.AddIngredient(ModContent.ItemType<BloodOfTheHellDemigod>(), 40); ;
            recipe.AddIngredient(ModContent.ItemType<IIVoidEssenceII>(), 25); ;
            recipe.AddIngredient(ModContent.ItemType<CursedCore>(), 4); ;
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