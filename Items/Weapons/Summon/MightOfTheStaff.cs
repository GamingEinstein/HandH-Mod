using HandHmod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Summon
{
    public class MightOfTheStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Might of the Staff");
            Tooltip.SetDefault("Summons a Spirit Star to fight for you.");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 3500;
            item.summon = true;
            item.mana = 100;
            item.width = 26;
            item.height = 28;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 30, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item44;
            item.shoot = ModContent.ProjectileType<MightOfTheMinion>();
            item.buffType = ModContent.BuffType<Buffs.SpiritStar>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }
    }
}