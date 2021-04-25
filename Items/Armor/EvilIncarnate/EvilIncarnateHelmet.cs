using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Armor.EvilIncarnate
{
    [AutoloadEquip(EquipType.Head)]
    public class EvilIncarnateHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Incarnate Helmet");
            Tooltip.SetDefault("The essence of hell is forged into this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 99);
            item.rare = ItemRarityID.Blue;
            item.defense = 90;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddIngredient(ItemID.SolarFlareHelmet, 1);
            recipe.AddIngredient(ItemType<HellFireBar>(), 95);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 90);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<EvilIncarnateChestplate>() && legs.type == ItemType<EvilIncarnateGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "75% increased melee and ranged damage" +
                              "\nIncreased movement speed" +
                              "\nYou have a permanent Archery Buff";
            player.meleeDamage += 0.75f;
            player.rangedDamage += 0.75f;
            player.AddBuff(BuffID.Archery, 2);
            player.moveSpeed += 50.5f;
        }
    }
}
