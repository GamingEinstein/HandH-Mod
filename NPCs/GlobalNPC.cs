using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs
{
    class MyGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.RedDevil)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Misc.Materials.DemonDust>()));
            }
            if (npc.type == NPCID.MartianSaucerCore)
            {
                Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Misc.Materials.MartianOrb>()));
            }
            if (npc.type == NPCID.ArmoredSkeleton)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Magic.NeoSpell>()));
            }
            if (npc.type == NPCID.GiantWormHead)
            {
                if (Main.rand.Next(6) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Magic.TunnelBuster>()));
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Accessories.MoonLordRibcage>()));
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Magic.TidalCrash>()));
            }
            if (npc.type == NPCID.ChaosElemental)
            {
                if (Main.rand.Next(6000) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Melee.GreenBoi>()));
            }
            if (npc.type == NPCID.EaterofSouls)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Range.GalaxyTwinkle>()));
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Melee.SteampunkDagger>()));
            }
            if (npc.type == NPCID.SkeletronPrime)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Melee.YakHunter>()));
            }
            if (npc.type == NPCID.DD2Betsy)
            {
                if (Main.rand.Next(60) == 0)
                    Item.NewItem(npc.getRect(), (ModContent.ItemType<Items.Weapons.Magic.DragonGaze>()));
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<HandHmodPlayer>().ZoneHeaven)
            {
                spawnRate = (int)(spawnRate * 5f);
                maxSpawns = (int)(maxSpawns * 5f);
            }
        }
    }
}
