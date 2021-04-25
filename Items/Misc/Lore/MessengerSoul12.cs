using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class DevourerOfHellfire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devourer of Hellfire");
            Tooltip.SetDefault("This worm isn't like others. It looks of Hell, but has powers like that of another world." +
                              "\n may god protect those brave enough to slay it...");
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