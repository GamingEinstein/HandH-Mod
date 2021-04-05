using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.BlissFire;
using HandHmod.Items.Misc.Materials;

namespace HandHmod.Items.Armor.HeavenBliss
{
    [AutoloadEquip(EquipType.Body)]
    public class HeavenBlissChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Bliss Chestplate");
            Tooltip.SetDefault("An ancient power is stored within this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 999);
            item.rare = ItemRarityID.Blue;
            item.defense = 210;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<BlissFireBar>(), 30);
            recipe.AddIngredient(ItemType<EyeOfTheDevourer>());
            recipe.AddIngredient(ItemType<CoreOfTheScourge>());
            recipe.AddIngredient(ItemType<BloodOfTheScourge>(), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}