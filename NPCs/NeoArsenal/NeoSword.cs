using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
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
			npc.width = 40;
			npc.height = 40;
			npc.damage = 200;
			npc.defense = 15;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.lavaImmune = true;
			npc.value = 6000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 23;
			aiType = NPCID.EnchantedSword;
			animationType = NPCID.EnchantedSword;
			bossBag = ModContent.ItemType<Items.Boss.DevourerOfHellfireTreasureBag>();
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/LastBattle");
		}
		public override void NPCLoot()
		{
			if (Main.rand.NextBool(10))
			{
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Boss.DevourerOfHellfireTrophy>());
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (Main.rand.NextBool(7))
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<EyeOfTheDevourer>(), 10);
				}
				Item.NewItem(npc.getRect(), ModContent.ItemType<HellFireBar>(), 800);
				Item.NewItem(npc.getRect(), ModContent.ItemType<HeavenFlameBar>(), 800);
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Misc.Lore.DevourerOfHellfire>());
				Item.NewItem(npc.getRect(), ModContent.ItemType<KnuckleCrusher>());
			}
		}
	}
}
 
