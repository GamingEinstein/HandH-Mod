using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class NeoSickle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Scythe");
            Tooltip.SetDefault("The Scythe once held by Neo himself..."); //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 60;
            item.height = 52;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
            item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
            item.shoot = ProjectileID.DeathSickle;
            item.shootSpeed = 4f;
        }
    }
}

