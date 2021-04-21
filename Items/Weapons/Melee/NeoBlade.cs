using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class NeoBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo's Sword");
            Tooltip.SetDefault("The ancient sword once held by Neo himself...");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.useTime = 7;
            item.useAnimation = 7;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
    }
}
