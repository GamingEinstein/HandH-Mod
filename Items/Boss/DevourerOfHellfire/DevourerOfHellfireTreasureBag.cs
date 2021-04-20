using HandHmod.Items.Developer.ProjectElements;
using HandHmod.Items.Developer.Pop;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using HandHmod.Items.Placeables.OreBars.HeavenFlame;
using HandHmod.Items.Misc.Materials;
using HandHmod.Items.Weapons.Melee;
using HandHmod.Items.Weapons.Magic;
using HandHmod.Items.Placeables.OreBars.HellFireFrag;

namespace HandHmod.Items.Boss.DevourerOfHellfire
{
    public class DevourerOfHellfireTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("DevourerOfHellfireHead");

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
                player.QuickSpawnItem(ItemID.GoldCoin, 10000);
                player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
                player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(3, 7));
                player.QuickSpawnItem(ItemType<HeavenFlameBar>(), Main.rand.Next(998, 999));
                player.QuickSpawnItem(ItemType<HellFireBar>(), Main.rand.Next(998, 999));
                player.QuickSpawnItem(ItemType<BlissFragment>(), Main.rand.Next(500, 999));
                player.QuickSpawnItem(ItemType<EyeOfTheDevourer>(), Main.rand.Next(10, 15));
                player.QuickSpawnItem(ItemType<DevourersTusk>(), Main.rand.Next(0, 1));
                player.QuickSpawnItem(ItemType<SoulsFracture>(), Main.rand.Next(0, 1));
                player.QuickSpawnItem(ItemType<Misc.Lore.DevourerOfHellfire>(), Main.rand.Next(0, 1));
                if (Main.rand.NextBool(100))
                {
                    player.QuickSpawnItem(ItemType<PopArmourHelmet>());
                    player.QuickSpawnItem(ItemType<PopArmourGreaves>());
                    player.QuickSpawnItem(ItemType<PopArmourChestplate>());
                    if (Main.rand.NextBool(100))
                    {
                        player.QuickSpawnItem(ItemType<DexArmourHelmet>());
                        player.QuickSpawnItem(ItemType<DexArmourGreaves>());
                        player.QuickSpawnItem(ItemType<DexArmourChestplate>());
                        if (Main.rand.Next(7) == 0)
                        {
                            player.QuickSpawnItem(ItemType<CurseOfHellfire>());
                        }
                        if (Main.rand.Next(100) == 0)
                        {
                            player.QuickSpawnItem(ItemType<DevourerOfHellfireTreasureBag>());
                        }
                    }
                }
            }
        }
    }
}