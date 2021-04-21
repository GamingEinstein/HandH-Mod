using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class TunnelBuster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tunnel Buster");
            Tooltip.SetDefault("Break rock with rock");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.magic = true;
            item.noMelee = false;
            item.mana = 5;
            item.width = 32;
            item.height = 32;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.BoulderStaffOfEarth;
            item.shootSpeed = 10f;
            item.autoReuse = true;
        }
    }
}
