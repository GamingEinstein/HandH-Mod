using HandHmod.Items.Weapons.Magic;
using HandHmod.Items.Weapons.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss.NeoArsenal
{
    public class NeoArsenalTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("NeoSword");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 36;
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
                player.QuickSpawnItem(ItemID.GoldCoin, 10);
                player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(5, 10));
                player.QuickSpawnItem(ItemID.ManaPotion, Main.rand.Next(3, 7));
                player.QuickSpawnItem(ItemType<Items.Misc.Materials.HeavenlySoul>(), Main.rand.Next(10, 30));
                player.QuickSpawnItem(ItemType<Items.Misc.Materials.CursedSoulOfHell>(), Main.rand.Next(10, 30));
                if (Main.rand.Next(7) == 0)
                {
                    player.QuickSpawnItem(ItemType<NeoSpell>());
                }
                if (Main.rand.NextBool(50))
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<NeoSpearWeapon>());
                    }
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<NeoBlade>());
                    }
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<NeoSickle>());
                    }
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<NeoBlood>());
                    }
                    if (Main.rand.Next(100) == 0)
                    {
                        player.QuickSpawnItem(ItemType<NeoArsenalTreasureBag>());
                    }
                }
            }
        }
    }
}