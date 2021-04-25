using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Hell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell");
            Tooltip.SetDefault("Most of Hell was crushed in the Great Crumble, " +
                              "\nleaving it a husk of its former self...");
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
