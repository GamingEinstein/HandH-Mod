using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class LakeScourge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lake Scourge");
            Tooltip.SetDefault("A creature born from the Manipulation of Kanadeus by Neo the Lesser, sealed at the ocean's floor " +
                              "\nit only looks to destroy any and all life it can find...");
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