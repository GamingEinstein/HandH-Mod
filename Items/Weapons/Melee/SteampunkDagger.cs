using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class SteampunkDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steampunk Dagger");
            Tooltip.SetDefault("Tick tock, bang bang..."); //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 85;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
            item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
            item.shoot = mod.ProjectileType("SpikySteamball");
            item.shootSpeed = 14f;
        }
    }
}