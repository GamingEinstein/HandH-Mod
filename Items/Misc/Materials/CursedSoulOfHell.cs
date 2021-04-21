using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
    public class HeavenlySoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenly Sould");
            Tooltip.SetDefault("A soul from the former Heavens");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(gold: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.maxStack = 999;
        }
    }
}