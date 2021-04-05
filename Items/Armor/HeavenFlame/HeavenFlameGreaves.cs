using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Misc.Materials;

namespace HandHmod.Items.Armor.HeavenFlame
{
    [AutoloadEquip(EquipType.Legs)]
    public class HeavenFlameGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Flame Greaves");
            Tooltip.SetDefault("The essence of Heaven is ingrained in this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 99);
            item.rare = ItemRarityID.Blue;
            item.defense = 55;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 25);
            recipe.AddIngredient(ItemID.NebulaLeggings, 1);
            recipe.AddIngredient(ItemType<HellFireBar>(), 5);
            recipe.AddIngredient(ItemType<HeavenDust>(), 15);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 75);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
