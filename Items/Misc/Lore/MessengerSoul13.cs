using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class NeoArsenal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Arsenal");
            Tooltip.SetDefault("The weapons of Neo the Lesser, confiscated when he was locked away in the Dungeon. As long as Neo's soul remains, they can never be gotten rid of...");
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
