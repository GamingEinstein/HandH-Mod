using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Arcani : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcani");
            Tooltip.SetDefault("Arcani... Demigod of Heaven..." +
                              "\n She held ultimate power over the heaven governments..." +
                              "\n While many may blame her for causing the Great Crumble by closing the passage" +
                              "\n between Heaven and Hell, her government simply didn't trust each other and hell" +
                              "\n and if it wasn't for them and Neo's treachery, she wouldn't have ever considered it...");
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
