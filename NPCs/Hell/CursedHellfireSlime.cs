using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.Hell
{
    public class CursedHellfireSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Hellfire Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.LavaSlime];
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 26;
            npc.damage = 150;
            npc.defense = 15;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.lavaImmune = true;
            npc.value = 6000f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 1;
            aiType = NPCID.LavaSlime;
            animationType = NPCID.LavaSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underworld.Chance * 0.5f;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HellFireFragment>(), 1);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CursedSoulOfHell>(), 5);
        }
    }
}
