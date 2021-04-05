using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using HandHmod.Projectiles.Bosses;
using HandHmod.Items;
using HandHmod.Items.Boss;
using HandHmod.Items.Weapons.Summon;
using HandHmod.Items.Weapons.Melee;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Weapons.Range;

namespace HandHmod.NPCs.MightOfTheUnderworld
{
    [AutoloadBossHead]
    public class MightOfTheUnderworld : ModNPC
    {
        // AI
        private int ai;
        private int attackTimer = 0;
        private bool fastSpeed = false;

        private bool stunned;
        private int stunnedTimer;

        // Animation
        private int frame = 0;
        private double counting;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Might of the Underworld");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 72;
			npc.height = 72;

			npc.boss = true;
			npc.aiStyle = -1;
			npc.npcSlots = 5f;

			npc.lifeMax = 500000;
			npc.damage = 250;
			npc.defense = 100;
			npc.knockBackResist = 0f;

			npc.value = Item.buyPrice(gold: 10);

			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/RunningHell");

            bossBag = mod.ItemType("MightOfTheUnderworldTreasureBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
			npc.damage = (int)(npc.damage * 1.3f);
		}



        public override void NPCLoot()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                for (int x = centerX - halfLength; x <= centerX + halfLength; x++)
                {
                    for (int y = centerY - halfLength; y <= centerY + halfLength; y++)
                    {
                        if ((x == centerX - halfLength || x == centerX + halfLength || y == centerY - halfLength || y == centerY + halfLength) && !Main.tile[x, y].active())
                        {
                            Main.tile[x, y].type = TileID.ObsidianBrick;
                            Main.tile[x, y].active(true);
                        }
                        Main.tile[x, y].lava(false);
                        Main.tile[x, y].liquid = 0;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        else
                        {
                            WorldGen.SquareTileFrame(x, y, true);
                        }
                    }
                }
            }
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<MightOfTheUnderworldTrophy>());
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (Main.rand.NextBool(7))
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<DeathbringerBow>());
                }
                Item.NewItem(npc.getRect(), ModContent.ItemType<MightOfTheStaff>());
                Item.NewItem(npc.getRect(), ModContent.ItemType<HyperDeathBringer>());
                Item.NewItem(npc.getRect(), ModContent.ItemType<HeavenAnnihilator>());
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Misc.Lore.MightOfTheUnderworld>());
                Item.NewItem(npc.getRect(), ModContent.ItemType<HeavenFlameBar>(), 333);
                Item.NewItem(npc.getRect(), ModContent.ItemType<HellFireBar>(), 777);
            }
        }



		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.HealingPotion;

			if (!HandHmodWorld.downedMightOfTheUnderworld)
			{
				HandHmodWorld.downedMightOfTheUnderworld = true;
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}
        private static int HellLayer => Main.maxTilesY - 200;

        public override void AI()
        {
            // Gets the Player and Target Vector
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            // Ensures that the NPC is not rotated
            npc.rotation = 0.0f;
            npc.netAlways = true;
            npc.TargetClosest(true);
            // Ensures NPC Life is not greater than its max life
            if (npc.life >= npc.lifeMax)
                npc.life = npc.lifeMax;
            // Handles Despawning
            if (npc.target < 0 || npc.target == 500 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }
            // Increment AI
            ai++;
            // Movement
            npc.ai[0] = (float)ai * 1f;
            int distance = (int)Vector2.Distance(target, npc.Center);
            if ((double)npc.ai[0] < 300)
            {
                frame = 0;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 450.0)
            {
                stunned = true;
                frame = 1;
                npc.defense = 1;
                npc.damage = 250;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 450.0)
            {
                frame = 0;
                stunned = false;
                npc.damage = 250;
                npc.defense = 100;
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                else
                {
                    if ((double)npc.ai[0] % 50 == 0)
                    {
                        float speed = 12f;
                        Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float x = player.position.X + (float)(player.width / 2) - vector.X;
                        float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                        float distance2 = (float)Math.Sqrt(x * x + y * y);
                        float factor = speed / distance2;
                        npc.velocity.X = x * factor;
                        npc.velocity.Y = y * factor;
                    }
                }
                npc.netUpdate = true;
            }
            // Attack
            if ((double)npc.ai[0] % (Main.expertMode ? 10 : 15) == 0 && !fastSpeed)
            {
                attackTimer++;
                if (attackTimer <= 2)
                {
                    frame = 2;
                    npc.velocity.X = 1f;
                    npc.velocity.Y = 1f;
                    Vector2 shootPos = npc.Center;
                    float accuracy = 5f * (npc.life / npc.lifeMax);
                    Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                    shootVel.Normalize();
                    shootVel *= 14.5F;
                    for (int i = 0; i < (Main.expertMode ? 5 : 3); i++)
                    {
                        Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, mod.ProjectileType("MightOfTheUnderworldProjectile"), npc.damage / 3, 5f);
                    }
                }
                else
                {
                    attackTimer = 0;
                }
            }



            if ((double)npc.ai[0] >= 650.0)
            {
                ai = 0;
                npc.alpha = 0;
                npc.ai[2] = 0;
                fastSpeed = false;
            }

        }

        public override void FindFrame(int frameHeight)
        {
            if (frame == 0)
            {
                counting += 1.0;
                if (counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else
                {
                    counting = 0.0;
                }
            }
            else if (frame == 1)
            {
                npc.frame.Y = frameHeight * 4;
            }
            else
            {
                npc.frame.Y = frameHeight * 5;
            }
        }

        private void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }
    }
}