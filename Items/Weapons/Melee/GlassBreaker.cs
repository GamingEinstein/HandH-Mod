using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class GlassBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Breaker");
            Tooltip.SetDefault("Shinyyyyy");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 15;
            item.value = Item.buyPrice(gold: 10);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.DiamondBolt;
            item.shootSpeed = 3f;
        }
    }
}
