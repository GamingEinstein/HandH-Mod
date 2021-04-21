using HandHmod.Tiles;
using HandHmod.Tiles.HeavenFlame;
using HandHmod.Tiles.HeavenTiles;
using HandHmod.Tiles.Walls;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace HandHmod.Generation
{
    public class Heavens
    {
        public static void Generate(int x, int y)
        {
            GenTiles(x, y);
        }

        private static void GenTiles(int x, int y)
        {
            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>
            {
                [new Color(0, 255, 255)] = ModContent.TileType<HeavenTile>(),
                [new Color(0, 100, 100)] = ModContent.TileType<HeavenFlameOre>(),
                [new Color(255, 255, 255)] = -1,
                [Color.Black] = -2
            };
            Dictionary<Color, int> colorToWall = new Dictionary<Color, int>
            {
                [new Color(0, 200, 200)] = ModContent.WallType<HeavenlyWall>(),
                [Color.Black] = -2
            };
            TexGen texGenerator = BaseWorldGenTex.GetTexGenerator(ModContent.GetTexture("HandHmod/Generation/Heavens"), colorToTile, ModContent.GetTexture("HandHmod/Generation/HeavensWalls"), colorToWall, ModContent.GetTexture("HandHmod/Generation/HeavensWater"));
            texGenerator.Generate(x - texGenerator.width / 2, y - texGenerator.height / 2, silent: true, sync: true);
            WorldGen.PlaceChest(x - 6, y + 229, (ushort)ModContent.TileType<HeavenlyChest>(), false, 1);
        }
    }
}
