using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class CorruptBeauty : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Beauty");
            Tooltip.SetDefault("The beauty of the evils...");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.magic = true;
            item.mana = 50;
            item.width = 96;
            item.height = 96;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.ShadowFlame;
            item.shootSpeed = 20f;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.RodOfTheScourge>()); ;
            recipe.AddIngredient(ModContent.ItemType<HeavenChargeStaff>()); ;
            recipe.AddIngredient(ModContent.ItemType<HellChargeStaff>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Materials.CoreOfTheScourge>(), 2); ;
            recipe.AddIngredient(ItemID.ShadowFlameHexDoll);
            recipe.AddIngredient(ItemID.Vilethorn);
            recipe.AddIngredient(ItemID.CrimsonRod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}