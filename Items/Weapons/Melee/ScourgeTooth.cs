using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class ScourgeTooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scourge Tooth");
            Tooltip.SetDefault("A tooth harvested from the Scourge.");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 99999);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 100;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.WaterBolt;
            item.shootSpeed = 15f;
        }
    }
}
