using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Devitrius : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devitrius");
            Tooltip.SetDefault("Devitrius... the Demigod ruler of the underworld...." +
                              "\n He held power over the underworld government..." +
                              "\n He was very good friends with Arcani before the great crumble..." +
                              "\n His body was distorted when they sealed THE VOID away, and he forever has a scar from" +
                              "\n his fight with Neo The Lesser...");
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
