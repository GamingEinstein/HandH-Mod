using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace HandHmod.Tiles.HellFireFrag
{
    public class HellFireBar : ModTile
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

            AddMapEntry(Color.DarkRed, Language.GetText("Hellfire Bar"));
        }

        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.frameX / 18;
            int itemType = ModContent.ItemType<Items.Placeables.OreBars.HellFireFrag.HellFireBar>();
            switch (style)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            Item.NewItem(i * 16, j * 16, 16, 16, itemType);
            return base.Drop(i, j);
        }
    }
}
