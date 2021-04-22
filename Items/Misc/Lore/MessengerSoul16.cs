using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Arcani : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcani");
            Tooltip.SetDefault("Demigod of the Heavens... (idk)");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.buyPrice(gold: 0);
            item.rare = ItemRarityID.Cyan;
            item.maxStack = 1;
        }
    }
}
