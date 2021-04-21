using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class RodOfTheScourge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rod of the Scourge");
            Tooltip.SetDefault("The treasure of the sea");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.magic = true;
            item.mana = 25;
            item.width = 56;
            item.height = 56;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.WaterStream;
            item.shootSpeed = 14f;
            item.autoReuse = true;
        }
    }
}
