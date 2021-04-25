using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class HellandGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Helland Greatsword");
            Tooltip.SetDefault("Forged of the riches of hell...");
        }

        public override void SetDefaults()
        {
            item.damage = 70;
            item.melee = true;
            item.width = 128;
            item.height = 128;
            item.useTime = 8;
            item.useAnimation = 8;
            item.knockBack = 2;
            item.value = Item.buyPrice(gold: 99);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 100;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.Flamelash;
            item.shootSpeed = 8f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Materials.DemonDust>());
            recipe.AddIngredient(ModContent.ItemType<DeathLight>());
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddIngredient(ItemID.FieryGreatsword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}