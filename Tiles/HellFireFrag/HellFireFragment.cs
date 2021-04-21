using Terraria;
using Terraria.ModLoader;

namespace HandHmod.Tiles.HellFireFrag
{
    public class HellFireFragment : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = false;

            drop = ModContent.ItemType<Items.Placeables.OreBars.HellFireFrag.HellFireFragment>();

            AddMapEntry(Microsoft.Xna.Framework.Color.DarkRed);

            minPick = 225;
        }
    }
}
