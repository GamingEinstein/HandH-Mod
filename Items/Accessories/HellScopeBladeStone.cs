using HandHmod.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Accessories
{
    public class HellScopeBladeStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Scope Blade Stone");
            Tooltip.SetDefault("Increases melee damage by 90%," +
                              "\n Increases ranged damage by 90%" +
                              "\n 18 extra defense," +
                              "\n applies permanent Inferno buff" +
                              "\n applies permanent IceBarrier buff" +
                               "\n applies permanent AmmoReservation buff" +
                              "\n applies permanent AmmoBox buff" +
                              "\n applies permanent Wrath buff");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // 50% melee and ranged damage increase
            player.meleeDamage += 0.9f;
            player.rangedDamage += 0.9f;
            player.AddBuff(BuffID.AmmoReservation, 2);
            player.AddBuff(BuffID.AmmoBox, 2);
            player.AddBuff(BuffID.Inferno, 2);
            player.AddBuff(BuffID.IceBarrier, 2);
            player.AddBuff(BuffID.Wrath, 2);
            player.statDefense += 18;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BladeStone>());
            recipe.AddIngredient(ModContent.ItemType<GunslingerStone>());
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.MechanicalGlove);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}