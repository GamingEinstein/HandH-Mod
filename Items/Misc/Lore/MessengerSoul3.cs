using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class IceWasteland : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Wasteland");
            Tooltip.SetDefault("A great ice mountain once contained a giant city. after the great crumble, the city disappeared into the snow...");
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
