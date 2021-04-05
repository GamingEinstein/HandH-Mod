using HandHmod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
	public class GreenBoi : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Boi");
			Tooltip.SetDefault("The worst sword in the game");
		}

		public override void SetDefaults()
		{
			item.damage = 3;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 200;
			item.useAnimation = 200;
			item.knockBack = 2000000;
			item.value = Item.buyPrice(copper: 1);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.crit = 50;
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 32000000);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 999);
			recipe.AddTile(ItemID.WorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
