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
            Tooltip.SetDefault("A creature born of the remnants of the souls of the seas in the time before, it only looks to consume more souls to sustain its form...");
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