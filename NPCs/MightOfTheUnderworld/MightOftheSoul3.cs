using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.MightOfTheUnderworld
{
    [AutoloadBossHead]
    public class MightOfTheSoul3 : ModNPC
    {
        public const string MightOfTheSoulHead = "HandHmod/NPCs/MightOfTheUnderworld/MightOfTheSoul_Head_Boss";

        public override bool Autoload(ref string name)
        {
            // Adds boss head textures for the Abomination boss
            for (int k = 1; k <= 4; k++)
            {
                mod.AddBossHeadTexture(MightOfTheSoulHead + k);
            }
            return base.Autoload(ref name);
        }

        private int center
        {
            get => (int)npc.ai[0];
            set => npc.ai[0] = value;
        }

        private int captiveType
        {
            get => (int)npc.ai[1];
            set => npc.ai[1] = value;
        }

        private float attackCool
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        private int change
        {
            get => (int)npc.ai[3];
            set => npc.ai[3] = value;
        }


        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
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
            DisplayName.SetDefault("Might of the Soul");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.width = 46;
            npc.height = 30;
            npc.boss = true;
            npc.aiStyle = -1;
            npc.lifeMax = 50000;
            npc.damage = 50;
            npc.defense = 100;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 10f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
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
            npc.ai[0] = ai * 1f;
            int distance = (int)Vector2.Distance(target, npc.Center);
            if ((double)npc.ai[0] < 300)
            {
                frame = 0;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 300 && npc.ai[0] < 450.0)
            {
                stunned = true;
                frame = 1;
                npc.defense = 100;
                npc.damage = 50;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if (npc.ai[0] >= 450.0)
            {
                frame = 0;
                stunned = false;
                npc.damage = 50;
                npc.defense = 100;
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                else
                {
                    if ((double)npc.ai[0] % 50 == 0)
                    {
                        float speed = 17f;
                        Vector2 vector = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        float x = player.position.X + player.width / 2 - vector.X;
                        float y = player.position.Y + player.height / 2 - vector.Y;
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
                        Projectile.NewProjectile(shootPos.X + -100 * npc.direction + Main.rand.Next(-40, 41), shootPos.Y - Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, mod.ProjectileType("MightOfTheUnderworldProjectile"), npc.damage / 1, 1);
                    }
                }
                else
                {
                    attackTimer = 0;
                }
            }



            if (npc.ai[0] >= 650.0)
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

