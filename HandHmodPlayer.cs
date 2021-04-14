using HandHmod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace HandHmod
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class HandHmodPlayer : ModPlayer
	{
		public bool MightOfTheMinion;

		public const int maxExampleLifeFruits = 10;
		public int exampleLifeFruits;

		public bool ZoneHeaven;

		public override void ResetEffects()
		{
			MightOfTheMinion = false;
			player.statLifeMax2 += exampleLifeFruits * 10;
		}
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Write(exampleLifeFruits);
			packet.Send(toWho, fromWho);
		}
		public override TagCompound Save()
		{
			return new TagCompound {
				{"exampleLifeFruits", exampleLifeFruits},
			};
		}
		public override void Load(TagCompound tag)
		{
			exampleLifeFruits = tag.GetInt("exampleLifeFruits");
		}
		public override void UpdateBiomes()
		{
			ZoneHeaven = HandHmodWorld.HeavenTile > 50;
		}

		public override bool CustomBiomesMatch(Player other)
		{
			HandHmodPlayer modOther = other.GetModPlayer<HandHmodPlayer>();
			return ZoneHeaven == modOther.ZoneHeaven;
			// If you have several Zones, you might find the &= operator or other logic operators useful:
			// bool allMatch = true;
			// allMatch &= ZoneExample == modOther.ZoneExample;
			// allMatch &= ZoneModel == modOther.ZoneModel;
			// return allMatch;
			// Here is an example just using && chained together in one statemeny 
			// return ZoneExample == modOther.ZoneExample && ZoneModel == modOther.ZoneModel;
		}

		public override void CopyCustomBiomesTo(Player other)
		{
			HandHmodPlayer modOther = other.GetModPlayer<HandHmodPlayer>();
			modOther.ZoneHeaven = ZoneHeaven;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneHeaven;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneHeaven = flags[0];
		}
		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneHeaven)
			{
				return mod.GetTexture("HeavenMapBackground");
			}
			return null;
		}
	}
}
