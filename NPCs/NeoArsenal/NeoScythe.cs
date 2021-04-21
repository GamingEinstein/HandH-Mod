using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.NeoArsenal
{
    [AutoloadBossHead]
    public class NeoScythe : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Scythe");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.EnchantedSword];
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.width = 60;
            npc.height = 52;
            npc.damage = 100;
            npc.defense = 15;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.lavaImmune = true;
            npc.value = 6000f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 23;
            aiType = NPCID.EnchantedSword;
            animationType = NPCID.EnchantedSword;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/NeoArsenal");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
    }
}