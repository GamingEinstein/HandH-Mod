using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class TidalCrash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tidal Crash");
            Tooltip.SetDefault("Sploosh!");
        }

        public override void SetDefaults()
        {
            item.damage = 155;
            item.magic = true;
            item.mana = 50;
            item.width = 28;
            item.height = 32;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 5);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.Typhoon;
            item.shootSpeed = 30f;
            item.autoReuse = true;
        }
    }
}
