using HandHmod.Items.Boss.NeoArsenal;
using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.NeoArsenal
{
    [AutoloadBossHead]
    public class NeoSword : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Sword");
            Main.npcFrameCount[npc.type] = 6;
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

        private int run
        {
            get => (int)npc.ai[2];
            set => npc.ai[2] = value;
        }

        private int jungleAI
        {
            get => (int)npc.ai[3];
            set => npc.ai[3] = value;
        }


        public override void SetDefaults()
        {
            npc.boss = true;
            npc.width = 128;
            npc.height = 88;
            npc.damage = 200;
            npc.defense = 20;
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.value = 6000f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = -1;
            bossBag = ModContent.ItemType<NeoArsenalTreasureBag>();

            Mod mod = ModLoader.GetMod("HandHmodMusic");
            if (mod != null)
            {
                music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/NeoArsenal");
            }
            else
            {
                music = MusicID.Boss1;
            }
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
            if (npc.life < npc.lifeMax / 2)
            {

                {
                    captiveType = 3;
                }
            }
            else
            {
                captiveType = 1;
            }
            Player player = Main.player[npc.target];
            if (npc.localAI[0] == 0f)
            {
                if (GetDebuff() >= 0f)
                {
                    npc.buffImmune[GetDebuff()] = true;
                }
                if (captiveType == 3)
                {
                    npc.buffImmune[20] = true;
                    npc.ai[3] = 1f;
                }
                if (captiveType == 0)
                {
                    npc.coldDamage = true;
                }
                if (captiveType == 1)
                {
                    npc.alpha = 100;
                }
                if (Main.expertMode)
                {
                    npc.damage = 60;
                }
                if (captiveType == 2)
                {
                    npc.damage += 20;
                }
                npc.localAI[0] = 1f;
                Main.PlaySound(SoundID.NPCDeath7, npc.position);
            }
            //run away
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
                        if (Main.npc[k].active && Main.npc[k].type == ModContent.NPCType<NeoSword>() && Main.npc[k].ai[2] == 0f)
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
            if (run < 2 && npc.timeLeft < 750)
            {
                npc.timeLeft = 750;
            }
            //move
            int count = 0;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && Main.npc[k].type == ModContent.NPCType<NeoSword>())
                {
                    count++;
                }
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
                LookToPlayer();
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
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5f * (float)Math.Cos(npc.rotation), speed * (float)Math.Sin(npc.rotation), ModContent.ProjectileType<Projectiles.Bosses.Hev>(), damage, 20f, Main.myPlayer, GetDebuff(), GetDebuffTime());
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
                    LookToPlayer();
                    float speed = 12.5f - 2.5f * (float)npc.life / (float)npc.lifeMax;
                    npc.velocity = speed * new Vector2((float)Math.Cos(npc.rotation), (float)Math.Sin(npc.rotation));
                    npc.netUpdate = true;
                }
                else
                {
                    LookInDirection(npc.velocity);
                    npc.velocity *= 0.995f;
                }
            }
        }

        private void LookToPlayer()
        {
            Vector2 look = Main.player[npc.target].Center - npc.Center;
            LookInDirection(look);
        }

        private void LookInDirection(Vector2 look)
        {
            float angle = 0.5f * (float)Math.PI;
            if (look.X != 0f)
            {
                angle = (float)Math.Atan(look.Y / look.X);
            }
            else if (look.Y < 0f)
            {
                angle += (float)Math.PI;
            }
            if (look.X < 0f)
            {
                angle += (float)Math.PI;
            }
            npc.rotation = angle;
        }
        public override void NPCLoot()
        {
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<NeoArsenalTrophy>());
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (Main.rand.NextBool(7))
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Weapons.Magic.NeoSpell>());
                }
                Item.NewItem(npc.getRect(), ModContent.ItemType<CursedSoulOfHell>(), 800);
                Item.NewItem(npc.getRect(), ModContent.ItemType<HeavenlySoul>(), 800);
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Weapons.Melee.NeoSpearWeapon>());
                Item.NewItem(npc.getRect(), ModContent.ItemType<NeoBlade>());
                Item.NewItem(npc.getRect(), ModContent.ItemType<NeoSickle>());
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "Neo's Arsenal";
            potionType = ItemID.GreaterHealingPotion;

            if (!HandHmodWorld.downedNeoArsenal)
            {
                HandHmodWorld.downedNeoArsenal = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
            }
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (captiveType == 2 && Main.expertMode)
            {
                cooldownSlot = 1;
            }
            return true;
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode || Main.rand.NextBool())
            {
                int debuff = GetDebuff();
                if (debuff >= 0)
                {
                    player.AddBuff(debuff, GetDebuffTime(), true);
                }
            }
        }

        public int GetDebuff()
        {
            switch (captiveType)
            {
                case 0:
                    return BuffID.Frostburn;
                case 1:
                    return BuffID.Venom;
                case 2:
                    return BuffID.Ichor;
                default:
                    return -1;
            }
        }

        public int GetDebuffTime()
        {
            int time;
            switch (captiveType)
            {
                case 0:
                    time = 400;
                    break;
                case 1:
                    time = 300;
                    break;
                case 3:
                    time = 400;
                    break;
                case 4:
                    time = 600;
                    break;
                default:
                    return -1;
            }
            return time;
        }


        public Color? GetColor()
        {
            switch (captiveType)
            {
                case 0:
                    return new Color(0, 230, 230);
                case 1:
                    return new Color(0, 153, 230);
                case 3:
                    return new Color(0, 178, 0);
                case 4:
                    return new Color(230, 192, 0);
                default:
                    return null;
            }
        }
    }
}

