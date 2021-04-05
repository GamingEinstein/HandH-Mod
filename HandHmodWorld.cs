using HandHmod.Items;
using HandHmod.Tiles.HeavenFlame;
using HandHmod.NPCs;
using HandHmod.Tiles;
using HandHmod.Tiles.HeavenTiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using HandHmod.Items.Weapons.Melee;

namespace HandHmod
{
    public class HandHmodWorld : ModWorld
    {
        public static bool downedMightOfTheUnderworld;
        public static int HeavenTile;
        public static bool downedLakeScourge;
        public static bool downedDevourerOfHellfire;
        public static bool downedNeoArsenal;
        public static bool downedVoidCharge;

        public override void Initialize()
        {
            downedNeoArsenal = false;
            downedLakeScourge = false;
            downedMightOfTheUnderworld = false;
            downedDevourerOfHellfire = false;
            downedVoidCharge = false;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedNeoArsenal)
            {
                downed.Add("NeoArsenal");
            }
            if (downedLakeScourge)
            {
                downed.Add("LakeScourge");
            }
            if (downedMightOfTheUnderworld)
            {
                downed.Add("MightOfTheUnderworld");
            }
            if (downedDevourerOfHellfire)
            {
                downed.Add("DevourerOfHellfire");
            }
            if (downedVoidCharge)
            {
                downed.Add("VoidCharge");
            }
            return new TagCompound
            {
                ["downed"] = downed
            };
        }
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedNeoArsenal = downed.Contains("NeoArsenal");
            downedLakeScourge = downed.Contains("LakeScourge");
            downedMightOfTheUnderworld = downed.Contains("MightOfTheUnderworld");
            downedDevourerOfHellfire = downed.Contains("DevourerOfHellfire");
            downedVoidCharge = downed.Contains("VoidCharge");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedNeoArsenal = flags[0];
                downedLakeScourge = flags[1];
                downedMightOfTheUnderworld = flags[2];
                downedDevourerOfHellfire = flags[3];
                downedVoidCharge = flags[4];

            }
            else
            {
                mod.Logger.WarnFormat("HandHmod: Unknown loadVersion: {0}", loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedNeoArsenal;
            flags[1] = downedLakeScourge;
            flags[2] = downedMightOfTheUnderworld;
            flags[3] = downedDevourerOfHellfire;
            flags[4] = downedVoidCharge;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedNeoArsenal = flags[0];
            downedLakeScourge = flags[1];
            downedMightOfTheUnderworld = flags[2];
            downedDevourerOfHellfire = flags[3];
            downedVoidCharge = flags[4];
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(x => x.Name.Equals("Shinies"));
            int microBiomesIndex = tasks.FindIndex(x => x.Name.Equals("Micro Biomes"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("HandHmod hell ores Generation", OreGeneration));
                tasks.Insert(shiniesIndex + 1, new PassLegacy("HandHmod heaven ores Generation", OreGeneration));
            }
            if (microBiomesIndex != -1)
            {
                tasks.Insert(microBiomesIndex + 1, new PassLegacy("Constructing the Heavens", HeavenlyPlace));
            }
        }
        private void OreGeneration(GenerationProgress progress)
        {
            progress.Message = "Generating HandHmod Ores";

            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 7E-04); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                Tile tile = Main.tile[x, y];
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(1, 7), WorldGen.genRand.Next(2, 5), ModContent.TileType<Tiles.HellFireFrag.HellFireFragment>());
                }

            }
            progress.Message = "Generating HandHmod Ores";

            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 7E-04); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY);

                Tile tile = Main.tile[x, y];
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(2, 5), ModContent.TileType<HeavenFlameOre>());
            }
        }
        private void HeavenlyPlace(GenerationProgress progress)
        {
            progress.Message = "Constructing the Heavens...";

            for (int z = 0; z < 1; z++)
            {
                int x = WorldGen.dungeonX;
                int y = (int)WorldGen.worldSurface;
                int TileType = ModContent.TileType<HeavenTile>();

                if (x / 2 < WorldGen.dungeonX)
                {
                    WorldGen.TileRunner(x + 300, y, 300, 150, TileType, false, 0, 0, false, true);
                }
                else
                {
                    WorldGen.TileRunner(x - 300, y, 300, 150, TileType, false, 0, 0, false, true);
                }
            }
        }
        public override void PostWorldGen()
        {
            int[] itemsToPlaceInLockedFrozenChests = { ModContent.ItemType<HeavenAnnihilator>(), ModContent.ItemType<Items.Misc.Lore.IceWasteland>() };
            int itemsToPlaceInLockedFrozenChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 27 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInLockedFrozenChests[itemsToPlaceInLockedFrozenChestsChoice]);
                            itemsToPlaceInLockedFrozenChestsChoice = (itemsToPlaceInLockedFrozenChestsChoice + 1) % itemsToPlaceInLockedFrozenChests.Length;
                            // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                            break;
                        }
                    }
                }
            }
            int[] itemsToPlaceInLockedJungleChests = { ModContent.ItemType<Items.Misc.Lore.Jungle>() };
            int itemsToPlaceInLockedJungleChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 24 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInLockedJungleChests[itemsToPlaceInLockedJungleChestsChoice]);
                            itemsToPlaceInLockedJungleChestsChoice = (itemsToPlaceInLockedJungleChestsChoice + 1) % itemsToPlaceInLockedJungleChests.Length;
                            // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                            break;
                        }
                    }
                }
            }
        }
        public override void TileCountsAvailable(int[] tileCounts)
        {
            HeavenTile = tileCounts[ModContent.TileType<HeavenTile>()];
        }
    }
}