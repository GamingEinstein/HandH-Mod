using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Placeables.OreBars.HeavenFlame
{
    public class HeavenFlameBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenflame Bar");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(16);
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(gold: 99);

            item.autoReuse = true;
            item.useTurn = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.consumable = true;
            item.maxStack = 999;

            item.createTile = TileType<Tiles.HeavenFlame.HeavenFlameBar>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<HeavenFlameOre>(), 12);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}