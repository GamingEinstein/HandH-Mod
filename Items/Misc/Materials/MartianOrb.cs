using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
    public class MartianOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Martian Orb");
            Tooltip.SetDefault("It came from SPACE!");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.maxStack = 999;
        }
    }
}
