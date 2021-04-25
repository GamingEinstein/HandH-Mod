using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.LakeScourge
{
    public class LakeStrider : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lake Strider");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Crimera];
        }

        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 48;
            npc.damage = 200;
            npc.defense = 1;
            npc.lifeMax = 30;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath7;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.value = 6000f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 5;
            npc.noTileCollide = true;
            aiType = NPCID.Crimera;
            animationType = NPCID.Crimera;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Ocean.Chance * 0.5f;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LakeSpiritFragment"), 2);
        }
    }
}
