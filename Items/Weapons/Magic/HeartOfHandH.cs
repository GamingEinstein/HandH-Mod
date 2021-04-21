using HandHmod.Items.Misc.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class HeartOfHandH : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart of Heaven and Hell");
            Tooltip.SetDefault("It beats with the heart of the world");
        }

        public override void SetDefaults()
        {
            item.damage = 20000;
            item.magic = true;
            item.mana = 75;
            item.width = 64;
            item.height = 64;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.InfernoFriendlyBlast;
            item.shootSpeed = 20f;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.LastPrism);
            recipe.AddIngredient(ItemID.RazorbladeTyphoon);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeables.OreBars.BlissFire.BlissFireBar>(), 45); ;
            recipe.AddIngredient(ModContent.ItemType<SoulsFracture>()); ;
            recipe.AddIngredient(ModContent.ItemType<CorruptBeauty>()); ;
            recipe.AddIngredient(ModContent.ItemType<InterstellarDrain>()); ;
            recipe.AddIngredient(ModContent.ItemType<RodOfTheScourge>()); ;
            recipe.AddIngredient(ModContent.ItemType<NeoSpell>()); ;
            recipe.AddIngredient(ModContent.ItemType<BloodOfTheHeavenDemigod>(), 40); ;
            recipe.AddIngredient(ModContent.ItemType<BloodOfTheHellDemigod>(), 40); ;
            recipe.AddIngredient(ModContent.ItemType<IIVoidEssenceII>(), 25); ;
            recipe.AddIngredient(ModContent.ItemType<CursedCore>(), 4); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
