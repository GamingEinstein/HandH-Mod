using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Ocean : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean");
            Tooltip.SetDefault("Something tells me this ginormous body of water holds many secrets still untold...");
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
