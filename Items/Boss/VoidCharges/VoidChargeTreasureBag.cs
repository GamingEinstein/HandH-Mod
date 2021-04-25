using HandHmod.Items.Developer.Pop;
using HandHmod.Items.Developer.ProjectElements;
using HandHmod.Items.Misc.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss.VoidCharges
{
    public class VoidChargeTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("VoidChargeHeaven");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Cyan;
            item.expert = true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();
            if (Main.rand.NextBool(1))
            {
                player.QuickSpawnItem(ItemID.GoldCoin, 100000);
                player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
                player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(3, 7));
                player.QuickSpawnItem(ItemType<IIVoidEssenceII>(), Main.rand.Next(30, 45));
                if (Main.rand.NextBool(100))
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<PopArmourHelmet>());
                        player.QuickSpawnItem(ItemType<PopArmourGreaves>());
                        player.QuickSpawnItem(ItemType<PopArmourChestplate>());
                        if (Main.rand.Next(7) == 0)
                        {
                            player.QuickSpawnItem(ItemType<DexArmourHelmet>());
                            player.QuickSpawnItem(ItemType<DexArmourGreaves>());
                            player.QuickSpawnItem(ItemType<DexArmourChestplate>());
                            if (Main.rand.Next(7) == 0)
                            {
                                player.QuickSpawnItem(ItemType<VoidLight>());
                            }
                            if (Main.rand.Next(100) == 0)
                            {
                                player.QuickSpawnItem(ItemType<VoidChargeTreasureBag>());
                            }
                        }
                    }
                }
            }
        }
    }
}
