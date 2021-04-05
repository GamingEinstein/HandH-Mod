using HandHmod.Items.Misc.Materials;
using HandHmod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
	public class HeavenChargeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven Charge Staff");
			Tooltip.SetDefault("A staff of the Heavens");
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.magic = true;
			item.mana = 20;
			item.width = 64;
			item.height = 64;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 300, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item33;
			item.shoot = ProjectileID.Bubble;
			item.shootSpeed = 12f;
			item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<HeavenlySoul>(), 40); ;
			recipe.AddIngredient(ItemID.HellstoneBar, 25);
			recipe.AddIngredient(ItemID.AmethystStaff);
			recipe.AddIngredient(ItemID.TopazStaff);
			recipe.AddIngredient(ItemID.EmeraldStaff);
			recipe.AddIngredient(ItemID.RubyStaff);
			recipe.AddIngredient(ItemID.DiamondStaff);
			recipe.AddIngredient(ItemID.SapphireStaff);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
