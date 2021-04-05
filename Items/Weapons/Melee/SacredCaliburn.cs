using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
	public class SacredCaliburn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sacred Caliburn");
			Tooltip.SetDefault("The most powerful of all the sacred swords");
		}

		public override void SetDefaults()
		{
			item.damage = 200;
			item.melee = true; // Whether your item is part of the melee class
			item.width = 40; // The item texture's width
			item.height = 40; // The item texture's height
			item.useTime = 13; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 13; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 10;
			item.value = Item.buyPrice(gold: 100);
			item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = false;
			item.crit = 20;

			//The useStyle of the item. 
			//Use useStyle 1 for normal swinging or for throwing
			//use useStyle 2 for an item that drinks such as a potion,
			//use useStyle 3 to make the sword act like a shortsword
			//use useStyle 4 for use like a life crystal,
			//and use useStyle 5 for staffs or guns
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<HeavenFlameBar>(), 9); ;
			recipe.AddIngredient(ModContent.ItemType<HeavenDust>(), 5); ;
			recipe.AddIngredient(ItemID.Excalibur);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.GoldBar, 99);
			recipe.AddIngredient(ItemID.GoldBroadsword, 2);
			recipe.AddIngredient(ItemID.TitaniumSword);
			recipe.AddIngredient(ItemID.Arkhalis);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 360);
			target.AddBuff(BuffID.CursedInferno, 360);
		}
	}
}