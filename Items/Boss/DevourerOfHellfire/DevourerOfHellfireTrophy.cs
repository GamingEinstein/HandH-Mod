﻿using HandHmod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Boss.DevourerOfHellfire
{
    public class DevourerOfHellfireTrophy : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 50000;
            item.rare = ItemRarityID.Blue;
            item.createTile = TileType<DevourerOfHellfireTrophyPlaced>();
            item.placeStyle = 0;
        }
    }
}