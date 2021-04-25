using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Placeables.OreBars.BlissFire;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Armor.HeavenBliss
{
    [AutoloadEquip(EquipType.Head)]
    public class HeavenBlissHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Bliss Helmet");
            Tooltip.SetDefault("An ancient power is stored within this armor.");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 99);
            item.rare = ItemRarityID.Blue;
            item.defense = 110;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<BlissFireBar>(), 25);
            recipe.AddIngredient(ItemType<EyeOfTheDevourer>());
            recipe.AddIngredient(ItemType<CoreOfTheScourge>());
            recipe.AddIngredient(ItemType<BloodOfTheScourge>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HeavenBlissChestplate>() && legs.type == ItemType<HeavenBlissGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increase in all damage by 2 times" +
                              "\nGrants multiple permanent buffs while wearing" +
                              "\nincreases minion slots by a lot";
            player.allDamage += 2f;
            player.moveSpeed += 60.5f;
            player.AddBuff(BuffID.Archery, 2);
            player.AddBuff(BuffID.Campfire, 2);
            player.AddBuff(BuffID.Ironskin, 2);
            player.AddBuff(BuffID.Lifeforce, 2);
            player.AddBuff(BuffID.ManaRegeneration, 2);
            player.AddBuff(BuffID.MagicPower, 2);
            player.AddBuff(BuffID.ObsidianSkin, 2);
            player.AddBuff(BuffID.Panic, 2);
            player.AddBuff(BuffID.Rage, 2);
            player.AddBuff(BuffID.RapidHealing, 2);
            player.AddBuff(BuffID.Shine, 2);
            player.AddBuff(BuffID.Spelunker, 2);
            player.AddBuff(BuffID.Swiftness, 2);
            player.AddBuff(BuffID.WeaponImbueIchor, 2);
            player.slotsMinions += 40;
            player.maxMinions += 40;
            player.minionDamage += 100f;
        }
    }
}