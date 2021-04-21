using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Accessories
{
    public class MoonLordRibcage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Lord's Ribcage");
            Tooltip.SetDefault("Increases melee damage by 75%," +
                              "\n 8 extra defense," +
                              "\n applies permanent AmmoReservation buff");
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
            player.meleeDamage += 0.75f;
            player.AddBuff(BuffID.AmmoReservation, 2);
            player.statDefense += 8;
        }
    }
}
