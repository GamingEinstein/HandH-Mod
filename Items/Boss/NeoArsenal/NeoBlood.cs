using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss.NeoArsenal
{
    public class NeoBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Blood");
            Tooltip.SetDefault("Summons Neo's Arsenal");
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
            return NPC.downedBoss2 && player.GetModPlayer<HandHmodPlayer>().ZoneHeaven && !NPC.AnyNPCs(NPCType<NPCs.NeoArsenal.NeoSword>()) && !NPC.AnyNPCs(NPCType<NPCs.NeoArsenal.NeoScythe>()) && !NPC.AnyNPCs(NPCType<NPCs.NeoArsenal.NeoSpear>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.NeoArsenal.NeoSword>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.NeoArsenal.NeoScythe>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.NeoArsenal.NeoSpear>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.Misc.Materials.HeavenDust>(), 10); ;
            recipe.AddIngredient(ItemID.GoldShortsword);
            recipe.AddIngredient(ItemID.PlatinumShortsword);
            recipe.AddIngredient(ItemID.BottledWater, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}