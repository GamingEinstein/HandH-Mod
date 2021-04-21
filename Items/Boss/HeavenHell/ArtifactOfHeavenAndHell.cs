using HandHmod.NPCs.Arcani;
using HandHmod.NPCs.Devitrius;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss
{
    public class ArtifactOfHeavenAndHell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Artifact of Heaven and Hell");
            Tooltip.SetDefault("Summons Arcani and Devitrius");
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
            return HandHmodWorld.downedVoidCharge && player.ZoneOverworldHeight && !NPC.AnyNPCs(NPCType<Arcani>()) && !NPC.AnyNPCs(NPCType<Devitrius>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<Arcani>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<Devitrius>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.Misc.Materials.IIVoidEssenceII>(), 90); ;
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemType<Items.Placeables.OreBars.HeavenFlame.HeavenFlameBar>(), 5); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
