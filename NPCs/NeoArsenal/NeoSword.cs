using HandHmod.Items.Boss.DevourerOfHellfire;
using HandHmod.Items.Boss.NeoArsenal;
using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Weapons.Melee;
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
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.EnchantedSword];
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.width = 44;
            npc.height = 44;
            npc.damage = 200;
            npc.defense = 20;
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.value = 6000f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 23;
            aiType = NPCID.EnchantedSword;
            animationType = NPCID.EnchantedSword;
            bossBag = ModContent.ItemType<NeoArsenalTreasureBag>();
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/NeoArsenal");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<DevourerOfHellfireTrophy>());
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
    }
}

