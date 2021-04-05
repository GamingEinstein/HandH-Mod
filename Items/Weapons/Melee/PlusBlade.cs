using HandHmod.Items.Misc.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
	public class PlusBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plus Blade");
			Tooltip.SetDefault("Fight.");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 5;
			item.useAnimation = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(gold: 1);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 6;
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeamSword);
			recipe.AddIngredient(ItemID.BloodButcherer);
			recipe.AddIngredient(ItemID.BloodWater);
			recipe.AddIngredient(ItemID.BloodyMachete);
			recipe.AddIngredient(ItemID.CrimtaneBar);
			recipe.AddIngredient(ItemID.HallowedBar);
			recipe.AddIngredient(ModContent.ItemType<HeavenDust>(), 5); ;
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 60);
		}
	}
}