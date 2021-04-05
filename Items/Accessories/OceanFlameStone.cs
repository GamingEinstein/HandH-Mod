using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Accessories
{
	public abstract class OceanFlameStone : ModItem
	{
        public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Green;
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			
			if (slot < 10)
			{
				
				int index = FindDifferentEquippedOceanFlameStone().index;
				if (index != -1)
				{
					return slot == index;
				}
			}
			return base.CanEquipAccessory(player, slot);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			
			Item accessory = FindDifferentEquippedOceanFlameStone().accessory;
			if (accessory != null)
			{
				tooltips.Add(new TooltipLine(mod, "Swap", "Right click to swap with '" + accessory.Name + "'!")
				{
					overrideColor = Color.OrangeRed
				});
			}
		}

		public override bool CanRightClick()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
			for (int i = 13; i < 13 + maxAccessoryIndex; i++)
			{
				if (Main.LocalPlayer.armor[i].type == item.type) return false;
			}

			
			if (FindDifferentEquippedOceanFlameStone().accessory != null)
			{
				return true;
			}
			
			return base.CanRightClick();
		}

		public override void RightClick(Player player)
		{
			
			var (index, accessory) = FindDifferentEquippedOceanFlameStone();
			if (accessory != null)
			{
				Main.LocalPlayer.QuickSpawnClonedItem(accessory);
				
				Main.LocalPlayer.armor[index] = item.Clone();
			}
		}

		
		protected (int index, Item accessory) FindDifferentEquippedOceanFlameStone()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;
			for (int i = 3; i < 3 + maxAccessoryIndex; i++)
			{
				Item otherAccessory = Main.LocalPlayer.armor[i];
				
				if (!otherAccessory.IsAir &&
					!item.IsTheSameAs(otherAccessory) &&
					otherAccessory.modItem is OceanFlameStone)
				{
					
					return (i, otherAccessory);
				}
			}
			
			return (-1, null);
		}
	}

	

	public class FlamingOceanicStone : OceanFlameStone
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flaming Oceanic Stone");
			Tooltip.SetDefault("Increases ranged damage by 50%, 2 extra defense");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			// 50% melee and ranged damage increase
			player.rangedDamage += 0.5f;
			player.statDefense += 2;
		}

		public override void RightClick(Player player)
		{
			// This is an example of working with methods in the inheritance chain (you don't need this RightClick() override for your accessory otherwise)

			// Here, before the parent's code is executed, we retrieve the name of the previously equipped item
			// We know guaranteed that there will be an item to be replaced, since otherwise this hook wouldn't run (condition in CanRightClick())
			string previousItemName = "";

			Item accessory = FindDifferentEquippedOceanFlameStone().accessory;
			if (accessory != null)
			{
				previousItemName = accessory.Name;
			}

			// In order to preserve its expected behavior (right click swaps this and a different currently equipped accessory)
			// we need to call the parent method via base.Method(arguments)
			// Removing this line will cause this item to just vanish when right clicked
			base.RightClick(player);

			// Here we add additional things that happen on right clicking this item
			Main.NewText("I just equipped " + item.Name + " in place of " + previousItemName + "!");
			Main.PlaySound(SoundID.MaxMana, (int)player.position.X, (int)player.position.Y);
		}
	}
}
