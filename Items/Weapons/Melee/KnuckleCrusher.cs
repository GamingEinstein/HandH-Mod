using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class KnuckleCrusher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knuckle Crusher");
            Tooltip.SetDefault("Crunch crunch slice.");
        }

        public override void SetDefaults()
        {
            item.damage = 85;
            item.melee = true;
            item.width = 900;
            item.height = 900;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 1000000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FetidBaghnakhs);
            recipe.AddIngredient(ModContent.ItemType<HellFireBar>(), 9);
            recipe.AddIngredient(ModContent.ItemType<HeavenFlameBar>(), 9);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 99);
            recipe.AddIngredient(ItemID.HallowedBar, 99);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}