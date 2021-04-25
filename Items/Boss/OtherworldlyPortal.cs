using HandHmod.Items.Boss.DevourerOfHellfire;
using HandHmod.Items.Boss.HeavenHell;
using HandHmod.Items.Boss.LakeScourge;
using HandHmod.Items.Boss.MightOfTheUnderworld;
using HandHmod.Items.Boss.Neo;
using HandHmod.Items.Boss.NeoArsenal;
using HandHmod.Items.Boss.VoidCharges;
using HandHmod.Items.Misc.Materials;
using HandHmod.NPCs.Arcani;
using HandHmod.NPCs.Devitrius;
using HandHmod.NPCs.DevourerOfHellfire;
using HandHmod.NPCs.LakeScourge;
using HandHmod.NPCs.MightOfTheUnderworld;
using HandHmod.NPCs.NeoArsenal;
using HandHmod.NPCs.NeoTheLesser;
using HandHmod.NPCs.VoidCharge;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss
{
    public class OtherworldlyPortal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Otherworldly Portal");
            Tooltip.SetDefault("Summons all HandHmod bosses!");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.rare = ItemRarityID.LightRed;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return HandHmodWorld.downedVoidCharge && player.ZoneOverworldHeight
                && !NPC.AnyNPCs(NPCType<NPCs.MightOfTheUnderworld.MightOfTheUnderworld>())
                && !NPC.AnyNPCs(NPCType<MightOfTheSoul>())
                && !NPC.AnyNPCs(NPCType<MightOfTheSoul2>())
                && !NPC.AnyNPCs(NPCType<MightOfTheSoul3>())
                && !NPC.AnyNPCs(NPCType<NPCs.LakeScourge.LakeScourge>())
                && !NPC.AnyNPCs(NPCType<DevourerOfHellfireHead>())
                && !NPC.AnyNPCs(NPCType<NeoSword>())
                && !NPC.AnyNPCs(NPCType<NeoScythe>())
                && !NPC.AnyNPCs(NPCType<NeoSpear>())
                && !NPC.AnyNPCs(NPCType<VoidChargeHell>())
                && !NPC.AnyNPCs(NPCType<VoidChargeHeaven>())
                && !NPC.AnyNPCs(NPCType<NPCs.NeoTheLesser.Neo>())
                && !NPC.AnyNPCs(NPCType<Arcani>())
                && !NPC.AnyNPCs(NPCType<Devitrius>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.LakeScourge.LakeScourge>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.MightOfTheUnderworld.MightOfTheUnderworld>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul2>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul3>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<DevourerOfHellfireHead>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NeoSpear>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NeoScythe>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NeoSword>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<VoidChargeHeaven>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<VoidChargeHell>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.NeoTheLesser.Neo>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<Arcani>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<Devitrius>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<CursedSoulsOfTheDamned>()); ;
            recipe.AddIngredient(ItemType<CurseOfHellfire>()); ;
            recipe.AddIngredient(ItemType<JewelOfTheScourge>()); ;
            recipe.AddIngredient(ItemType<NeoBlood>()); ;
            recipe.AddIngredient(ItemType<VoidLight>()); ;
            recipe.AddIngredient(ItemType<NeoSoul>()); ;
            recipe.AddIngredient(ItemType<ArtifactOfHeavenAndHell>()); ;
            recipe.AddIngredient(ItemType<IIVoidEssenceII>(), 90); ;
            recipe.AddIngredient(ItemType<BloodOfTheHeavenDemigod>(), 2); ;
            recipe.AddIngredient(ItemType<BloodOfTheHellDemigod>(), 2); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}