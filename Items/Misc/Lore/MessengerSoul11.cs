using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class MightOfTheUnderworld : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Might of the Underworld");
            Tooltip.SetDefault("The vengeful souls who died in the great crumble formed into a creature hellbent on innacting revenge on those who failed to protect them...");
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