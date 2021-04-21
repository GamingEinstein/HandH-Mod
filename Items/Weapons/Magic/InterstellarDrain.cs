using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class InterstellarDrain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Interstellar Drain");
            Tooltip.SetDefault("The second word would make a good gang...");
        }

        public override void SetDefaults()
        {
            item.damage = 1000;
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
            item.shoot = ProjectileID.LunarFlare;
            item.shootSpeed = 30f;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.LastPrism);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeables.OreBars.BlissFire.BlissFireBar>(), 25); ;
            recipe.AddIngredient(ModContent.ItemType<SoulsFracture>()); ;
            recipe.AddIngredient(ModContent.ItemType<NeoSpell>()); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

