using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class NeoTheLesser : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo the Lesser");
            Tooltip.SetDefault("When he was younger, he had caused both the Heavens and Hell to break ties from each other..." +
                               "\nThe Demigods have tried to imprison him, but it would only be a matter of time until he escaped...");
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
