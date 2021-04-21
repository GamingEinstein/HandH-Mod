using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Magic
{
    public class NeoSpell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Spell");
            Tooltip.SetDefault("The magic wielded by Neo himself...");
        }

        public override void SetDefaults()
        {
            item.damage = 35;
            item.magic = true;
            item.mana = 50;
            item.width = 28;
            item.height = 32;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 300, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item33;
            item.shoot = ProjectileID.Typhoon;
            item.shootSpeed = 2f;
            item.autoReuse = true;
        }
    }
}
