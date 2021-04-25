using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Materials
{
    public class BloodOfTheHellDemigod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood of the Hell Demigod");
            Tooltip.SetDefault("The essence of the Demigod ruler of Hell");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = Item.buyPrice(gold: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.maxStack = 999;
        }
    }
}
