using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Underground : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Underground");
            Tooltip.SetDefault("These caves contain the most of the remnants of the former surface and heaven, " +
                              "\nand they radiate dark energy...");
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
