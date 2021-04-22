using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class VoidCharges : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Void Charges");
            Tooltip.SetDefault("The Scouts of THE VOID... They aimlessly search for creatures to send information about to THE VOID..." +
                               "\nGod help you if you try to challenge them...");
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
