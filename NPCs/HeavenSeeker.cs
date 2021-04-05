using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs
{
	public class HeavenSeeker : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven Seeker");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Crimera];
		}

		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 64;
			npc.damage = 20;
			npc.defense = 5;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.value = 6000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 5;
			npc.noTileCollide = false;
			aiType = NPCID.Crimera;
			animationType = NPCID.Crimera;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.GetModPlayer<HandHmodPlayer>().ZoneHeaven ? .5f : .5f;
		}
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HeavenDust"), 5);
		}
	}
}