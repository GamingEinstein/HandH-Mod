using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class NeoDarkCreationStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Dark Creation Staff");
            Tooltip.SetDefault("It contains the power of the mage, Neo the Lesser...");
        }

        public override void SetDefaults()
        {
            item.damage = 115;
            item.magic = true;
            item.mana = 25;
            item.width = 64;
            item.height = 64;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.LunarFlare;
            item.shootSpeed = 30f;
            item.autoReuse = true;
        }
    }
}
