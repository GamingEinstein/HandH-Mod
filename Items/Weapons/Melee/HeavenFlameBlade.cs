using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class HeavenFlameBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven Flameblade");
            Tooltip.SetDefault("It slices through both heaven and hell.");  //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 95; // The damage your item deals
            item.melee = true; // Whether your item is part of the melee class
            item.width = 20;
            item.height = 20;
            item.useTime = 5;// The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 5;// The time span of the using animation of the weapon, suggest setting it the same as useTime.
            item.knockBack = 6; // The force of knockback of the weapon. Maximum is 20
            item.value = Item.buyPrice(gold: 99); // The value of the weapon in copper coins
            item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
            item.crit = 10; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance

            //The useStyle of the item. 
            //Use useStyle 1 for normal swinging or for throwing
            //use useStyle 2 for an item that drinks such as a potion,
            //use useStyle 3 to make the sword act like a shortsword
            //use useStyle 4 for use like a life crystal,
            //and use useStyle 5 for staffs or guns
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
            item.shoot = 503;
            item.shootSpeed = 1f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                position.Y -= (100 * i);
                Vector2 heading = target - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y + Main.rand.Next(-40, 41) * 0.2f;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HeavenFlameBar>(), 99); ;
            recipe.AddRecipeGroup("IronBar", 12);
            recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddIngredient(ItemID.Starfury, 1);
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 120);
        }
    }
}
