using HandHmod.Generation;
using HandHmod.Items.Weapons.Melee;
using HandHmod.Tiles.HeavenFlame;
using HandHmod.Tiles.HeavenTiles;
using HandHmod.Tiles.HellFireFrag;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

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
        public static bool downedDemigod;
        public static bool downedNeo;

        public override void Initialize()
        {
            downedNeoArsenal = false;
            downedLakeScourge = false;
            downedMightOfTheUnderworld = false;
            downedDevourerOfHellfire = false;
            downedVoidCharge = false;
            downedDemigod = false;
            downedNeo = false;
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
            if (downedNeo)
            {
                downed.Add("Neo");
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
            if (downedDemigod)
            {
                downed.Add("Demigod");
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
            downedLakeScourge = downed.Contains("Neo");
            downedMightOfTheUnderworld = downed.Contains("MightOfTheUnderworld");
            downedDevourerOfHellfire = downed.Contains("DevourerOfHellfire");
            downedVoidCharge = downed.Contains("VoidCharge");
            downedDemigod = downed.Contains("Demigod");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedNeoArsenal = flags[0];
                downedLakeScourge = flags[1];
                downedLakeScourge = flags[2];
                downedMightOfTheUnderworld = flags[3];
                downedDevourerOfHellfire = flags[4];
                downedVoidCharge = flags[5];
                downedDemigod = flags[6];

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
            flags[2] = downedNeo;
            flags[3] = downedMightOfTheUnderworld;
            flags[4] = downedDevourerOfHellfire;
            flags[5] = downedVoidCharge;
            flags[6] = downedDemigod;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedNeoArsenal = flags[0];
            downedLakeScourge = flags[1];
            downedLakeScourge = flags[2];
            downedMightOfTheUnderworld = flags[3];
            downedDevourerOfHellfire = flags[4];
            downedVoidCharge = flags[5];
            downedDemigod = flags[6];
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int num1 = tasks.FindIndex(x => x.Name.Equals("Shinies"));
            if (num1 != -1)
            {
                tasks.Insert(num1 + 1, (GenPass)new PassLegacy("Spreading the fragments", new WorldGenLegacyMethod(OreGeneration)));

                int num2 = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Slush"));
                if (num2 != -1)
                {
                    tasks.Insert(num2 + 1, (GenPass)new PassLegacy("Placing the Heavens", new WorldGenLegacyMethod(GenHeavenClear)));
                    int num3 = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Micro Biomes"));
                    if (num3 != -1)
                    {
                        tasks.Insert(num3 + 1, (GenPass)new PassLegacy("Constructing the Heavens", new WorldGenLegacyMethod(GenHeaven)));
                    }
                }
            }
        }
        private void OreGeneration(GenerationProgress progress)
        {
            progress.Message = "Spreading the Fragments";
            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 7E-04); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                Tile tile = Main.tile[x, y];
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(1, 7), WorldGen.genRand.Next(2, 5), ModContent.TileType<HellFireFragment>());
                }

            }

            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 7E-04); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY);

                Tile tile = Main.tile[x, y];
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(2, 5), ModContent.TileType<HeavenFlameOre>());
            }
        }
        private void GenHeaven(GenerationProgress progress)
        {
            int x = (int)((float)Main.maxTilesX * 0f);
            int y = (int)((float)Main.maxTilesY * 0f);
            if (Main.dungeonX < Main.maxTilesX / 2)
            {
                x = (int)((float)Main.dungeonX + 700);
            }
            else
            {
                x = (int)((float)Main.dungeonX - 700);
            }

            if (Main.maxTilesX == 4200 && Main.maxTilesY == 1200)
            {
                y = (int)((float)Main.maxTilesY * 0.38f);
            }
            if (Main.maxTilesX == 6400 && Main.maxTilesY == 1800)
            {
                y = (int)((float)Main.maxTilesY * 0.32f);
            }
            if (Main.maxTilesX == 8400 && Main.maxTilesY == 2400)
            {
                y = (int)((float)Main.maxTilesY * 0.28f);
            }
            Heavens.Generate(x, y);
        }

        private void GenHeavenClear(GenerationProgress progress)
        {
            int x = (int)((float)Main.maxTilesX * 0f);
            int y = (int)((float)Main.maxTilesY * 0f);
            if (Main.dungeonX < Main.maxTilesX / 2)
            {
                x = (int)((float)Main.dungeonX + 700);
            }
            else
            {
                x = (int)((float)Main.dungeonX - 700);
            }

            if (Main.maxTilesX == 4200 && Main.maxTilesY == 1200)
            {
                y = (int)((float)Main.maxTilesY * 0.38f);
            }
            if (Main.maxTilesX == 6400 && Main.maxTilesY == 1800)
            {
                y = (int)((float)Main.maxTilesY * 0.32f);
            }
            if (Main.maxTilesX == 8400 && Main.maxTilesY == 2400)
            {
                y = (int)((float)Main.maxTilesY * 0.28f);
            }
            HeavensClear.Generate(x, y);
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