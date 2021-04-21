using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.NeoTheLesser
{
    [AutoloadBossHead]
    public class Neo : ModNPC
    {
        private int run
        {
            get => (int)npc.ai[2];
            set => npc.ai[2] = value;
        }
        private int captiveType
        {
            get => (int)npc.ai[0];
            set => npc.ai[0] = value;
        }
        private float attackCool
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }
        private int jungleAI
        {
            get => (int)npc.ai[3];
            set => npc.ai[3] = value;
        }
        public static int attack;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo the Lesser");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 50000;
            npc.damage = 150;
            npc.defense = 60;
            npc.knockBackResist = 0f;
            npc.width = 86;
            npc.height = 82;
            npc.value = Item.sellPrice(copper: 1);
            npc.npcSlots = 10f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath7;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Rapid4");
            //bossBag = ModContent.ItemType<NeoTreasureBag>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter -= 0.25f; // Determines the animation speed. Higher value = faster animation.
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = -frame * frameHeight;
        }
        public override void AI()
        {
            if (npc.life < npc.lifeMax / 1.01)
            {

                {
                    Main.NewText("Neo: So you want to fight me? Ok, let's fight!");
                    captiveType = 1;
                }
            }
            else
            {
                captiveType = 1;
            }

            Player player = Main.player[npc.target];
            //Run
            if ((!player.active || player.dead))
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    run = 1;
                }
                else
                {
                    run = 0;
                }
            }
            if (run > 0)
            {
                bool flag = true;
                if (run == 1)
                {
                    for (int k = 0; k < 200; k++)
                    {
                        if (Main.npc[k].active && Main.npc[k].type == ModContent.NPCType<Neo>() && Main.npc[k].ai[2] == 0f)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    run = 2;
                    npc.velocity = new Vector2(0f, 10f);
                    npc.rotation = 0.5f * (float)Math.PI;
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    npc.netUpdate = true;
                    return;
                }
            }
            int count = 0;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && Main.npc[k].type == ModContent.NPCType<Neo>())
                {
                    count++;
                }
            }
            if (npc.life < npc.lifeMax / 2)
            {

                {
                    Main.NewText("Neo: So you're looking to dismantle the abominations I made? You have no chance with your current power...");
                    captiveType = 1;
                }
            }
            else
            {
                captiveType = 1;
            }
            if (npc.life < npc.lifeMax / 4)
            {

                {
                    Main.NewText("Neo: You destroyed my arsenal, my aquatic destruction creature, the remnants of Cthuhlu, and now you want to destroy me...");
                    captiveType = 1;
                }
            }
            else
            {
                captiveType = 1;
            }
            if (npc.life < npc.lifeMax / 8)
            {

                {
                    Main.NewText("Neo: I wonder where Arcani and Devitrius are... It's been a while since I've had consciousness");
                    captiveType = 1;
                }
            }
            else
            {
                captiveType = 1;
            }
            if (npc.life < npc.lifeMax / 20)
            {

                {
                    Main.NewText("Neo: I see your potential. I trust that you can destroy all that I left behind...");
                    captiveType = 1;
                }
            }
            else
            {
                captiveType = 1;
            }
            if (captiveType != 1 && captiveType != 4)
            {
                Vector2 moveTo = player.Center;
                if (captiveType == 0)
                {
                    moveTo.Y -= 320f;
                }
                if (captiveType == 2)
                {
                    moveTo.Y += 320f;
                }
                if (captiveType == 3)
                {
                    if (jungleAI < 0)
                    {
                        moveTo.X -= 320f;
                    }
                    else
                    {
                        moveTo.X += 320f;
                    }
                }
                float minX = moveTo.X - 50f;
                float maxX = moveTo.X + 50f;
                float minY = moveTo.Y;
                float maxY = moveTo.Y;
                if (captiveType == 0)
                {
                    minY -= 50f;
                }
                if (captiveType == 2)
                {
                    maxY += 50f;
                }
                if (captiveType == 3)
                {
                    minY -= 240f;
                    maxY += 240f;
                }
                if (npc.Center.X >= minX && npc.Center.X <= maxX && npc.Center.Y >= minY && npc.Center.Y <= maxY)
                {
                    npc.velocity *= 0.98f;
                }
                else
                {
                    Vector2 move = moveTo - npc.Center;
                    float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                    float speed = 10f;
                    if (captiveType == 3 && (jungleAI == -5 || jungleAI == 1))
                    {
                        speed = 80f;
                    }
                    if (magnitude > speed)
                    {
                        move *= speed / magnitude;
                    }
                    float inertia = 10f;
                    if (speed == 8f)
                    {
                        inertia = 20f;
                    }
                    npc.velocity = (inertia * npc.velocity + move) / (inertia + 1);
                    magnitude = (float)Math.Sqrt(npc.velocity.X * npc.velocity.X + npc.velocity.Y + npc.velocity.Y);
                    if (magnitude > speed)
                    {
                        npc.velocity *= speed / magnitude;
                    }
                }
            }
            if (captiveType == 1)
            {
                Vector2 move = player.Center - npc.Center;
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                if (magnitude > 3.5f)
                {
                    move *= 5.5f / magnitude;
                }
                npc.velocity = move;
            }
            //look and shoot
            if (captiveType != 4)
            {
                attackCool -= 1f;
                if (attackCool <= 0f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (captiveType == 3)
                    {
                        jungleAI++;
                        if (jungleAI == 0)
                        {
                            jungleAI = 1;
                        }
                        if (jungleAI == 6)
                        {
                            jungleAI = -5;
                        }
                    }
                    attackCool = 150f + 100f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(50);
                    attackCool *= (float)count / 5f;
                    if (captiveType != 3 || jungleAI != -5 && jungleAI != 1)
                    {
                        int damage = npc.damage / 2;
                        if (Main.expertMode)
                        {
                            damage = (int)(damage / Main.expertDamage);
                        }
                        float speed = 50f;
                        if (captiveType != 1)
                        {
                            speed = Main.expertMode ? 90f : 70f;
                        }
                        switch (attack)
                        {
                            case 0:
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 82, 5f * (float)Math.Cos(npc.rotation), speed * (float)Math.Sin(npc.rotation), ProjectileID.CultistBossIceMist, damage, 40f);
                                break;
                            case 1:
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5f * (float)Math.Cos(npc.rotation), speed * (float)Math.Sin(npc.rotation), ProjectileID.CultistBossLightningOrb, damage, 40f);
                                break;
                            case 2:
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5f * (float)Math.Cos(npc.rotation), speed * (float)Math.Sin(npc.rotation), ProjectileID.CultistBossFireBall, damage, 40f);
                                break;
                        }
                        attack++;
                        if (attack >= 3)
                        {
                            attack = 0;
                        }
                    }
                    npc.TargetClosest(true);
                    npc.netUpdate = true;
                }
            }
            else
            {
                attackCool -= 1f;
                if (attackCool <= 0f)
                {
                    attackCool = 80f + 40f * (float)npc.life / (float)npc.lifeMax;
                    attackCool *= (float)count / 5f;
                    npc.TargetClosest(false);
                    float speed = 12.5f - 2.5f * (float)npc.life / (float)npc.lifeMax;
                    npc.velocity = speed * new Vector2((float)Math.Cos(npc.rotation), (float)Math.Sin(npc.rotation));
                    npc.netUpdate = true;
                }
                else
                {
                    npc.velocity *= 0.995f;
                }

            }
        }
    }
}