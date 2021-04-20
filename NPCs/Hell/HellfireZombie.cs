using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs
{
	public class HellfireZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellfire Zombie");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 200;
			npc.defense = 15;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.lavaImmune = true;
			npc.value = 6000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
			animationType = NPCID.Zombie;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Underworld.Chance * 0.5f;
		}
			public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HellFireFragment>(), 2);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CursedSoulOfHell>(), 2);
		}
	}
}
