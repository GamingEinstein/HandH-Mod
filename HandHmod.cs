using HandHmod.Items.Accessories;
using HandHmod.Items.Boss.DevourerOfHellfire;
using HandHmod.Items.Boss.HeavenHell;
using HandHmod.Items.Boss.LakeScourge;
using HandHmod.Items.Boss.MightOfTheUnderworld;
using HandHmod.Items.Boss.Neo;
using HandHmod.Items.Boss.NeoArsenal;
using HandHmod.Items.Boss.VoidCharges;
using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using HandHmod.Items.Weapons.Magic;
using HandHmod.Items.Weapons.Melee;
using HandHmod.Items.Weapons.Range;
using HandHmod.Items.Weapons.Summon;
using HandHmod.NPCs.Arcani;
using HandHmod.NPCs.Devitrius;
using HandHmod.NPCs.DevourerOfHellfire;
using HandHmod.NPCs.LakeScourge;
using HandHmod.NPCs.MightOfTheUnderworld;
using HandHmod.NPCs.NeoArsenal;
using HandHmod.NPCs.NeoTheLesser;
using HandHmod.NPCs.VoidCharge;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace HandHmod
{
    public class HandHmod : Mod
    {
        public bool MightOfTheMinion { get; internal set; }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    4.5f,
                    new List<int> { ModContent.NPCType<NeoSword>(), ModContent.NPCType<NeoSpear>(), ModContent.NPCType<NeoScythe>() },
                    this,
                    "Neo's Arsenal",
                    (Func<bool>)(() => HandHmodWorld.downedNeoArsenal),
                    ModContent.ItemType<NeoBlood>(),
                    new List<int> { ModContent.ItemType<NeoArsenalTrophy>() },
                    new List<int> { ModContent.ItemType<NeoSickle>(), ModContent.ItemType<NeoBlade>(), ModContent.ItemType<NeoSpearWeapon>(), ModContent.ItemType<HeavenlySoul>(), ModContent.ItemType<CursedSoulOfHell>(), ModContent.ItemType<NeoSpell>() },
                    "$Use [i: " + ModContent.ItemType<NeoBlood>() + "] in the heaven's fragment biome"
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
                    9.5f,
                    new List<int> { ModContent.NPCType<Neo>() },
                    this, // Mod
                    "Neo The Lesser",
                    (Func<bool>)(() => HandHmodWorld.downedNeo),
                    ModContent.ItemType<NeoSoul>(),
                    new List<int> { ModContent.ItemType<NeoTrophy>() },
                    new List<int> { ModContent.ItemType<HeavenFlameBar>(), ModContent.ItemType<NeoDarkCreationStaff>(), ModContent.ItemType<NeoBlade>(), ModContent.ItemType<NeoSickle>(), ModContent.ItemType<NeoSpearWeapon>(), },
                    "$Use [i: " + ModContent.ItemType<NeoSoul>() + "]"
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
                    ModContent.ItemType<VoidLight>(),
                    new List<int> { ModContent.ItemType<VoidChargeTrophyHeaven>() }, ModContent.ItemType<VoidChargeTrophyHell>(),
                    new List<int> { ModContent.ItemType<IIVoidEssenceII>() },
                    "$Use [i: " + ModContent.ItemType<VoidLight>() + "]"
                    );
                bossChecklist.Call(
                    "AddBoss",
                    19.5f,
                    new List<int> { ModContent.NPCType<Arcani>(), ModContent.NPCType<Devitrius>() },
                    this,
                    "Devitrius and Arcani",
                    (Func<bool>)(() => HandHmodWorld.downedDemigod),
                    ModContent.ItemType<ArtifactOfHeavenAndHell>(),
                    new List<int> { ModContent.ItemType<ArcaniTrophy>() }, ModContent.ItemType<DevitriusTrophy>(),
                    new List<int> { ModContent.ItemType<CursedCore>(), ModContent.ItemType<BloodOfTheHellDemigod>(), ModContent.ItemType<BloodOfTheHeavenDemigod>(), ModContent.ItemType<ArcaStaff>(), ModContent.ItemType<DeviStaff>(), },
                    "$Use [i: " + ModContent.ItemType<ArtifactOfHeavenAndHell>() + "]"
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
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/HeavenBiome");
                priority = MusicPriority.BiomeHigh;
            }
            if (Main.LocalPlayer.GetModPlayer<HandHmodPlayer>().ZoneHeaven && Main.LocalPlayer.position.Y / 16 > Main.worldSurface)
            {
                music = GetSoundSlot(SoundType.Music, "Sound/Music.HeavenBiomeUnderground");
                priority = MusicPriority.BiomeHigh;
            }
        }
    }
}