using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Tiles.HeavenTiles
{
    public class HeavenTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            drop = ItemType<Items.Placeables.OreBars.HeavenFlame.HeavenFragment>();

            ModTranslation name = CreateMapEntryName();
            AddMapEntry(Color.Cyan);

            minPick = 300;
        }
    }
}
