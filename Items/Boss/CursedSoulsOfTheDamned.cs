using HandHmod.NPCs.MightOfTheUnderworld;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss
{
    public class CursedSoulsOfTheDamned : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Souls of the Damned");
            Tooltip.SetDefault("Summons Might of the Underworld");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.rare = ItemRarityID.LightRed;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return NPC.downedMoonlord && player.ZoneUnderworldHeight && !NPC.AnyNPCs(NPCType<MightOfTheUnderworld>()) && !NPC.AnyNPCs(NPCType<MightOfTheSoul>()) && !NPC.AnyNPCs(NPCType<MightOfTheSoul2>()) && !NPC.AnyNPCs(NPCType<MightOfTheSoul3>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheUnderworld>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul2>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<MightOfTheSoul3>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<SpiritEye>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 12);
            recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddIngredient(ItemID.ShroomiteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
