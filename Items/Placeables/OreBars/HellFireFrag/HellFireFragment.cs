using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Placeables.OreBars.HellFireFrag
{
    public class HellFireFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Fragment");
        }
        public override void SetDefaults()
        {
            //Hitbox Size
            item.width = 12;
            item.height = 12;
            // Stack and Value
            item.maxStack = 999;
            item.value = Item.buyPrice(gold: 90);
            item.rare = ItemRarityID.Cyan;
            item.consumable = true;
            //usage
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            // create tile
            item.createTile = ModContent.TileType<Tiles.HellFireFrag.HellFireFragment>();
        }
    }
}
