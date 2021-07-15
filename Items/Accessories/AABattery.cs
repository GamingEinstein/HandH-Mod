using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.accessories
{
    public class AABattery : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AA Battery");
            Tooltip.SetDefault("Increases minions by 1\nIncreases minion damage by 4%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 36;
            item.height = 36;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 80, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 1;
            player.minionDamage += 0.04f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}