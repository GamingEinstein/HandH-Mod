using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.BlissFire;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Armor.HeavenBliss
{
    [AutoloadEquip(EquipType.Legs)]
    public class HeavenBlissGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Bliss Greaves");
            Tooltip.SetDefault("An ancient power is stored within this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 99);
            item.rare = ItemRarityID.Blue;
            item.defense = 90;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<BlissFireBar>(), 20);
            recipe.AddIngredient(ItemType<EyeOfTheDevourer>());
            recipe.AddIngredient(ItemType<CoreOfTheScourge>());
            recipe.AddIngredient(ItemType<BloodOfTheScourge>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}