using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc.Lore
{
    public class Dungeon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dungeon");
            Tooltip.SetDefault("This ancient structure reeks of ancient power. like there are multiple seals to it's secrets that must be broken...");
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

