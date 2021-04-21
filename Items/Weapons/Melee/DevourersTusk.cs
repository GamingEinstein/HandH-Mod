using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class DevourersTusk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devourer's Tusk");
            Tooltip.SetDefault("It brings only pain to those who are on the recieving end.");
        }

        public override void SetDefaults()
        {
            item.damage = 550;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 5;
            item.useAnimation = 5;
            item.knockBack = 20;
            item.value = Item.buyPrice(gold: 99999);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 100;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.IceBolt;
            item.shoot = ProjectileID.Flamelash;
            item.shootSpeed = 8f;
        }
    }
}
