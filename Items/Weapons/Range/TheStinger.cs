﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class TheStinger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Stinger");
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.BeeGun);
            item.width = refItem.width;
            item.height = refItem.height;
            item.ranged = true;
            item.damage = 20;
            item.rare = ItemRarityID.Blue;
            item.useTime = 20;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 5f;
            item.value = Item.sellPrice(copper: 1);
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Stinger;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger, 10);
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddIngredient(ItemID.BottledHoney, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}