using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Armor.HeavenFlame
{
    [AutoloadEquip(EquipType.Head)]
    public class HeavenFlameHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Flame Helmet");
            Tooltip.SetDefault("The essence of Heaven is engrained into this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 99);
            item.rare = ItemRarityID.Blue;
            item.defense = 65;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddIngredient(ItemID.NebulaHelmet, 1);
            recipe.AddIngredient(ItemType<HellFireBar>(), 10);
            recipe.AddIngredient(ItemType<HeavenFlameBar>(), 80);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HeavenFlameChestplate>() && legs.type == ItemType<HeavenFlameGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases magic and minion damage by 75%" +
                              "\nGreatly increased movement speed and extra minions";
            player.magicDamage += 0.75f;
            player.minionDamage += 0.75f;
            player.slotsMinions += 20;
            player.moveSpeed += 50.5f;
        }
    }
}
