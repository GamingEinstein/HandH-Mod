using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
    public class IIVoidEssenceII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("II Void Essence II");
            Tooltip.SetDefault("II the end... II");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(gold: 50);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.maxStack = 999;
        }
    }
}
