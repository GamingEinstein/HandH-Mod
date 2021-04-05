﻿using HandHmod.Items.Boss;
using HandHmod.NPCs.LakeScourge;
using HandHmod.NPCs.MightOfTheUnderworld;
using HandHmod.NPCs.DevourerOfHellfire;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
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
            return HandHmodWorld.downedDevourerOfHellfire && player.ZoneOverworldHeight && !NPC.AnyNPCs(NPCType<MightOfTheUnderworld>()) && !NPC.AnyNPCs(NPCType<MightOfTheSoul>()) && !NPC.AnyNPCs(NPCType<MightOfTheSoul2>()) && !NPC.AnyNPCs(NPCType<MightOfTheSoul3>()) && !NPC.AnyNPCs(NPCType<LakeScourge>()) && !NPC.AnyNPCs(NPCType<DevourerOfHellfireHead>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<LakeScourge>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheUnderworld>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul2>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul3>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<DevourerOfHellfireHead>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<CursedSoulsOfTheDamned>()); ;
            recipe.AddIngredient(ItemType<CurseOfHellfire>()); ;
            recipe.AddIngredient(ItemType<JewelOfTheScourge>()); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}