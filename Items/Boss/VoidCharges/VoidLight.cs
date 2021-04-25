using HandHmod.NPCs.VoidCharge;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss.VoidCharges
{
    public class VoidLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Light");
            Tooltip.SetDefault("Summons the Void Charges");
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
            return HandHmodWorld.downedDevourerOfHellfire && player.ZoneOverworldHeight && !NPC.AnyNPCs(NPCType<VoidChargeHeaven>()) && !NPC.AnyNPCs(NPCType<VoidChargeHell>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<VoidChargeHell>());
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<VoidChargeHeaven>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar);
            recipe.AddIngredient(ItemID.ShroomiteBar);
            recipe.AddIngredient(ItemID.SpectreBar);
            recipe.AddIngredient(ItemID.CelestialSigil);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddIngredient(ItemID.MechanicalSkull);
            recipe.AddIngredient(ItemID.MechanicalWorm);
            recipe.AddIngredient(ItemID.MechanicalEye);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.ClothierVoodooDoll);
            recipe.AddIngredient(ItemID.SuspiciousLookingEye);
            recipe.AddIngredient(ItemID.SlimeCrown);
            recipe.AddIngredient(ItemType<Placeables.OreBars.HeavenFlame.HeavenFlameBar>(), 10); ;
            recipe.AddIngredient(ItemType<Placeables.OreBars.HellFireFrag.HellFireBar>(), 10); ;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
