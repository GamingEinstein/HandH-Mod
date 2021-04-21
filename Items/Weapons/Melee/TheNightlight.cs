using HandHmod.Items.Misc.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class TheNightlight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Nightlight");
            Tooltip.SetDefault("night night");
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 15;
            item.value = Item.buyPrice(gold: 10);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.CursedFlameFriendly;
            item.shootSpeed = 15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CursedSoulOfHell>(), 9);
            recipe.AddIngredient(ItemID.NightsEdge);
            recipe.AddIngredient(ItemID.DarkLance);
            recipe.AddIngredient(ItemID.Arkhalis);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}



