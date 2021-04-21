using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Placeables.OreBars.BlissFire
{
    public class BlissFireBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blissfire Bar");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(16);
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(gold: 999);
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<HeavenFlame.HeavenFlameBar>(), 8);
            recipe.AddIngredient(ItemType<Misc.Materials.BlissFragment>());
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
