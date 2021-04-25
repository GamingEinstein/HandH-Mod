using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Accessories
{
    public class GunslingerStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gunslinger Stone");
            Tooltip.SetDefault("Increases ranged damage by 90%," +
                              "\n 4 extra defense," +
                              "\n applies permanent AmmoReservation buff" +
                              "\n applies permanent AmmoBox buff" +
                              "\n applies permanent Inferno buff");
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
            player.rangedDamage += 0.9f;
            player.AddBuff(BuffID.AmmoReservation, 2);
            player.AddBuff(BuffID.AmmoBox, 2);
            player.AddBuff(BuffID.Inferno, 2);
            player.statDefense += 4;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OceanFlameStone>());
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}