using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Weapons.Melee
{
    public class YakHunter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yak Hunter");
            Tooltip.SetDefault(" the sky calls...");
        }

        public override void SetDefaults()
        {
            item.damage = 125;
            item.melee = true; // Whether your item is part of the melee class
            item.width = 45; // The item texture's width
            item.height = 63; // The item texture's height
            item.useTime = 13; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 13; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            item.knockBack = 10;
            item.value = Item.buyPrice(gold: 100);
            item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = true;
            item.crit = 20;
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
        }
    }
}
