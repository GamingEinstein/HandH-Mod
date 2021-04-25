using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Tiles.HeavenFlame
{
    public class HeavenFlameBar : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(204, 194, 101), Language.GetText("MapObject.heavenflamebar"));
        }

        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.frameX / 18;
            int type = ItemType<Items.Placeables.OreBars.HeavenFlame.HeavenFlameBar>();
            switch (style)
            {
                case 1:
                    type = ItemType<Items.Placeables.OreBars.HeavenFlame.HeavenFlameBar>();
                    break;
                default:
                    break;
            }
            Item.NewItem(i * 16, j * 16, 16, 16, type);
            return base.Drop(i, j);
        }
    }
}