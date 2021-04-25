using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class DeathLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Light");
            Tooltip.SetDefault("Welcome to death. We hope you enjoy your stay.");
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 12;
            item.useAnimation = 12;
            item.knockBack = 15;
            item.value = Item.buyPrice(gold: 50);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.ShadowBeamFriendly;
            item.shootSpeed = 12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TheNightlight>()); ;
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(ItemID.ShroomiteBar);
            recipe.AddIngredient(ItemID.BeetleHusk);
            recipe.AddIngredient(ItemID.SpectreBar);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}