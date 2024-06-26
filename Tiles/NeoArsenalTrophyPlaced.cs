﻿using HandHmod.Items.Boss.NeoArsenal;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace HandHmod.Tiles
{
    public class NeoArsenalTrophyPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            dustType = 7;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Trophy");
            AddMapEntry(new Color(120, 85, 60), name);
            drop = ModContent.ItemType<NeoArsenalTrophy>();
        }
    }
}
