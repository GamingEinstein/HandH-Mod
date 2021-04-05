using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Tiles.HeavenFlame
{
    public class HeavenFlameOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            drop = ItemType<Items.Placeables.OreBars.HeavenFlame.HeavenFlameOre>();

            ModTranslation name = CreateMapEntryName();
            AddMapEntry(Microsoft.Xna.Framework.Color.LightCyan);

            minPick = 200;
        }
    }
}
