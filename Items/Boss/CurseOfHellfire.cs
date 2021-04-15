using HandHmod.NPCs.Boss.DevourerOfHellfire;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;

namespace HandHmod.Items.Boss
{
    public class CurseOfHellfire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Curse Of Hellfire");
            Tooltip.SetDefault("Summons the Devourer Of Hellfire");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 4;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return HandHmodWorld.downedMightOfTheUnderworld && player.ZoneOverworldHeight && !NPC.AnyNPCs(NPCType<DevourerOfHellfireHead>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<DevourerOfHellfireHead>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.SolarTablet);
            recipe.AddIngredient(ItemID.CelestialSigil);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 20); ;
            recipe.AddIngredient(ItemType<HellFireBar>(), 50); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}