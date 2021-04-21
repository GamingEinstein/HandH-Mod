using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Deserts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert");
            Tooltip.SetDefault("Many say there used to be a grand ocean covering these sands before the Great Crumble, but no one knows how they dried up...");
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
