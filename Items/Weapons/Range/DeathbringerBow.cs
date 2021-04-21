using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Range
{
    public class DeathbringerBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deathbringer Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A bow created to hunt down cursed souls.");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(12, 24);
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(platinum: 99);

            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item5;

            item.noMelee = true;
            item.ranged = true;
            item.damage = 354;

            item.useAmmo = AmmoID.Arrow;
            item.shoot = 100;
            item.shootSpeed = 1000f;
            item.autoReuse = true;
        }
    }
}