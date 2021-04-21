using HandHmod.Items.Boss.DevourerOfHellfire;
using HandHmod.Items.Boss.LakeScourge;
using HandHmod.Items.Boss.MightOfTheUnderworld;
using HandHmod.NPCs.Boss.DevourerOfHellfire;
using HandHmod.NPCs.Boss.MightOfTheUnderworld;
using HandHmod.NPCs.MightOfTheUnderworld;
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
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return HandHmodWorld.downedDevourerOfHellfire && player.ZoneOverworldHeight && !NPC.AnyNPCs(
                NPCType<NPCs.Boss.MightOfTheUnderworld.MightOfTheUnderworld>())
                && !NPC.AnyNPCs(NPCType<MightOfTheSoul>())
                && !NPC.AnyNPCs(NPCType<MightOfTheSoul2>())
                && !NPC.AnyNPCs(NPCType<MightOfTheSoul3>())
                && !NPC.AnyNPCs(NPCType<NPCs.Boss.LakeScourge.LakeScourge>())
                && !NPC.AnyNPCs(NPCType<DevourerOfHellfireHead>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Boss.LakeScourge.LakeScourge>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Boss.MightOfTheUnderworld.MightOfTheUnderworld>());
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