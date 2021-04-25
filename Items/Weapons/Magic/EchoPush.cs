using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class EchoPush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Echo Push");
            Tooltip.SetDefault("You are now the hero of this world...");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.magic = true;
            item.mana = 50;
            item.width = 50;
            item.height = 50;
            item.useTime = 6;
            item.useAnimation = 6;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 50;
            item.value = Item.buyPrice(0, 300, 0, 5);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = mod.ProjectileType("EchoPushProjectile");
            item.shootSpeed = 8f;
            item.autoReuse = true;
        }
    }
}
