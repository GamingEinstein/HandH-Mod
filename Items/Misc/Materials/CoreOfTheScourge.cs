using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
    public class CoreOfTheScourge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of the Scourge");
            Tooltip.SetDefault("The center of the very form of the Scourge");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.buyPrice(gold: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.maxStack = 999;
        }
    }
}
