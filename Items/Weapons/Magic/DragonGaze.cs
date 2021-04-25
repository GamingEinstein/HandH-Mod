using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class DragonGaze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Gaze");
            Tooltip.SetDefault("It Stares...");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.magic = true;
            item.mana = 30;
            item.width = 128;
            item.height = 128;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.LostSoulFriendly;
            item.shootSpeed = 20f;
            item.autoReuse = true;
        }
    }
}
