using HandHmod;
using HandHmod.Tiles;
using HandHmod.NPCs.NeoArsenal;
using HandHmod.NPCs.LakeScourge;
using HandHmod.NPCs.MightOfTheUnderworld;
using HandHmod.NPCs.DevourerOfHellfire;
using HandHmod.NPCs.VoidCharge;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using HandHmod.Items;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using HandHmod.Items.Boss;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Accessories;
using HandHmod.Items.Weapons.Melee;
using HandHmod.Items.Weapons.Magic;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Weapons.Summon;
using HandHmod.Items.Weapons.Range;

namespace HandHmod
{
	public class HandHmod : Mod
	{
		public bool MightOfTheMinion { get; internal set; }

		public override void Load()
		{

		}
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					5.5f,
					new List<int> { ModContent.NPCType<NeoScythe>(), ModContent.NPCType<NeoSpear>(), ModContent.NPCType<NeoSword>() },
					this,
					"Neo's Arsenal",
					(Func<bool>)(() => HandHmodWorld.downedNeoArsenal),
					null,
					null,
					null,
					"$Use (item go here)"
					);
				bossChecklist.Call(
					"AddBoss",
					7.5f,
					new List<int> { ModContent.NPCType<LakeScourge>() },
					this, // Mod
					"Lake Scourge",
					(Func<bool>)(() => HandHmodWorld.downedLakeScourge),
					ModContent.ItemType<JewelOfTheScourge>(),
					new List<int> { ModContent.ItemType<LakeScourgeTrophy>() },
					new List<int> { ModContent.ItemType<HeavenFlameBar>(), ModContent.ItemType<LakeSpiritFragment>(), ModContent.ItemType<FlamingOceanicStone>(), ModContent.ItemType<BloodOfTheScourge>(), ModContent.ItemType<CoreOfTheScourge>(), ModContent.ItemType<ScourgeTooth>(), ModContent.ItemType<RodOfTheScourge>() },
					"$Use [i: " + ModContent.ItemType<JewelOfTheScourge>() + "] at the ocean"
					);
				bossChecklist.Call(
					"AddBoss",
					16.5f,
					new List<int> { ModContent.NPCType<MightOfTheUnderworld>(), ModContent.NPCType<MightOfTheSoul>() },
					this, // Mod
					"Might of the Underworld",
					(Func<bool>)(() => HandHmodWorld.downedMightOfTheUnderworld),
					ModContent.ItemType<CursedSoulsOfTheDamned>(),
					new List<int> { ModContent.ItemType<MightOfTheUnderworldTrophy>() },
					new List<int> { ModContent.ItemType<HeavenFlameBar>(), ModContent.ItemType<DeathbringerBow>(), ModContent.ItemType<HyperDeathBringer>(), ModContent.ItemType<HellFireBar>(), ModContent.ItemType<MightOfTheStaff>() },
					"$Use [i: " + ModContent.ItemType<CursedSoulsOfTheDamned>() + "] in the Underworld"
					);
				bossChecklist.Call(
					"AddBoss",
					17.5f,
					new List<int> { ModContent.NPCType<DevourerOfHellfireHead>() },
					this, // Mod
					"Devourer of Hellfire",
					(Func<bool>)(() => HandHmodWorld.downedDevourerOfHellfire),
					ModContent.ItemType<CurseOfHellfire>(),
					new List<int> { ModContent.ItemType<DevourerOfHellfireTrophy>() },
					new List<int> { ModContent.ItemType<HeavenFlameBar>(), ModContent.ItemType<BlissFragment>(), ModContent.ItemType<HellFireBar>(), ModContent.ItemType<EyeOfTheDevourer>(), ModContent.ItemType<SoulsFracture>(), ModContent.ItemType<DevourersTusk>() },
					"$Use [i: " + ModContent.ItemType<CurseOfHellfire>() + "]"
					);
				bossChecklist.Call(
					"AddBoss",
					18.5f,
					new List<int> { ModContent.NPCType<VoidChargeHeaven>(), ModContent.NPCType<VoidChargeHell>() },
					this,
					"The Void Charges",
					(Func<bool>)(() => HandHmodWorld.downedVoidCharge),
					null,
					null,
					null,
					"$Use (item go here)"
					);
			}
		}
		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}
			// Make sure your logic here goes from lowest priority to highest so your intended priority is maintained.
			if (Main.LocalPlayer.GetModPlayer<HandHmodPlayer>().ZoneHeaven)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/BlessingOfTheMoon");
				priority = MusicPriority.BiomeHigh;
			}
		}
	}
}