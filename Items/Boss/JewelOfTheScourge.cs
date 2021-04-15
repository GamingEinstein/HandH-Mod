using HandHmod.NPCs.Boss.LakeScourge;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Misc.Materials;

namespace HandHmod.Items.Boss
{
    public class JewelOfTheScourge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jewel of the Scourge");
            Tooltip.SetDefault("Summons the Lake Scourge");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.rare = ItemRarityID.LightRed;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return NPC.downedMechBossAny && player.ZoneBeach && !NPC.AnyNPCs(NPCType<LakeScourge>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<LakeScourge>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 1); ;
            recipe.AddIngredient(ItemType<LakeSpiritFragment>(), 20); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}