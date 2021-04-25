using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class DeviStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devi staff");
            Tooltip.SetDefault("The power of the Hell Demigod resides in this staff...");
        }

        public override void SetDefaults()
        {
            item.damage = 1050;
            item.magic = true;
            item.mana = 75;
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
