using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Placeables.OreBars.HeavenFlame
{
    public class HeavenFlameOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenflame Ore");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(12);
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(gold: 90);
            item.autoReuse = true;
            item.useTurn = true;
            item.useTime = 10;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.consumable = true;
            item.maxStack = 999;

            item.createTile = TileType<Tiles.HeavenFlame.HeavenFlameOre>();
        }
    }
}