using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;

namespace HandHmod.Items.Armor.EvilIncarnate
{
    [AutoloadEquip(EquipType.Body)]
    public class EvilIncarnateChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Incarnate Chestplate");
            Tooltip.SetDefault("The essence of hell is forged into this armor");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 999);
            item.rare = ItemRarityID.Blue;
            item.defense = 100;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 30);
            recipe.AddIngredient(ItemID.FragmentVortex, 50);
            recipe.AddIngredient(ItemID.FragmentSolar, 50);
            recipe.AddIngredient(ItemID.SolarFlareBreastplate, 1);
            recipe.AddIngredient(ItemType<HellFireBar>(), 99);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 99);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
