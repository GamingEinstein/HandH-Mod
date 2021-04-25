using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Accessories
{
    public class BladeStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade Stone");
            Tooltip.SetDefault("Increases melee damage by 90%," +
                              "\n 12 extra defense," +
                              "\n applies permanent Inferno buff" +
                              "\n applies permanent IceBarrier buff" +
                              "\n applies permanent Wrath buff");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // 50% melee and ranged damage increase
            player.meleeDamage += 0.9f;
            player.AddBuff(BuffID.Inferno, 2);
            player.AddBuff(BuffID.IceBarrier, 2);
            player.AddBuff(BuffID.Wrath, 2);
            player.statDefense += 12;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MoonLordRibcage>());
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.MechanicalGlove);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}