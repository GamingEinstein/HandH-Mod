using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.NPCs.Boss.MightOfTheUnderworld
{
    public class SpiritEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Eye");
        }
        public override void SetDefaults()
        {
            npc.width = 46;
            npc.height = 46;
            npc.aiStyle = 14;
            npc.lifeMax = 450;
            npc.damage = 100;
            npc.defense = 200;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
    }
}
