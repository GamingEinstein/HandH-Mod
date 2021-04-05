using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;

namespace HandHmod.Items.Armor.HeavenFlame
{
    [AutoloadEquip(EquipType.Body)]
    public class HeavenFlameChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Flame Chestplate");
            Tooltip.SetDefault("The essence of Heaven is ingrained in this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 999);
            item.rare = ItemRarityID.Blue;
            item.defense = 75;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 30);
            recipe.AddIngredient(ItemID.FragmentNebula, 50);
            recipe.AddIngredient(ItemID.FragmentStardust, 50);
            recipe.AddIngredient(ItemID.NebulaBreastplate, 1);
            recipe.AddIngredient(ItemType<HellFireBar>(), 11);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 99);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}