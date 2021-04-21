using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class HeavenAnnihilator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven Annihilator");
            Tooltip.SetDefault("The bane of all Hell creatures. only to be wielded by the worthy...");
        }

        public override void SetDefaults()
        {
            item.damage = 1;
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
            item.shoot = 503;
            item.shootSpeed = 10f;
            if (HandHmodWorld.downedMightOfTheUnderworld)
            {
                item.damage = (int)(item.damage * 500f);
            }
        }
    }
}
