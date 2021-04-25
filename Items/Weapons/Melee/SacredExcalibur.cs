using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.BlissFire;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class SacredExcalibur : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacred Excalibur");
            Tooltip.SetDefault("The most powerful of all the sacred swords in one... Excalibur...");
        }

        public override void SetDefaults()
        {
            item.damage = 20000;
            item.melee = true; // Whether your item is part of the melee class
            item.width = 80; // The item texture's width
            item.height = 80; // The item texture's height
            item.useTime = 7; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 7; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            item.knockBack = 20;
            item.value = Item.buyPrice(gold: 10000);
            item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = true;
            item.crit = 20;
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
            item.shoot = 132;
            item.shootSpeed = 60f;
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
            recipe.AddIngredient(ModContent.ItemType<SacredCaliburn>()); ;
            recipe.AddIngredient(ModContent.ItemType<HyperDeathBringer>()); ;
            recipe.AddIngredient(ItemID.Excalibur, 4);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 10);
            recipe.AddIngredient(ModContent.ItemType<BlissFireBar>(), 95); ;
            recipe.AddIngredient(ModContent.ItemType<CursedSoulOfHell>(), 90); ;
            recipe.AddIngredient(ModContent.ItemType<HeavenAnnihilator>());
            recipe.AddIngredient(ItemID.Arkhalis, 2);
            recipe.AddIngredient(ModContent.ItemType<HeavenlySoul>(), 90); ;
            recipe.AddIngredient(ModContent.ItemType<BloodOfTheHeavenDemigod>(), 40); ;
            recipe.AddIngredient(ModContent.ItemType<BloodOfTheHellDemigod>(), 40); ;
            recipe.AddIngredient(ModContent.ItemType<IIVoidEssenceII>(), 25); ;
            recipe.AddIngredient(ModContent.ItemType<CursedCore>(), 4); ;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Bleeding, 360);
            target.AddBuff(BuffID.CursedInferno, 360);
            target.AddBuff(BuffID.ShadowFlame, 360);
            target.AddBuff(BuffID.Poisoned, 360);
            target.AddBuff(BuffID.Venom, 360);
            target.AddBuff(BuffID.Ichor, 360);
            target.AddBuff(BuffID.Burning, 360);
            target.AddBuff(BuffID.Frozen, 360);
            target.AddBuff(BuffID.Frostburn, 360);
            target.AddBuff(BuffID.Slow, 360);
        }
    }
}