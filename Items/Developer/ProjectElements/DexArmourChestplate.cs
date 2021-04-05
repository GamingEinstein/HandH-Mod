using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace HandHmod.Items.Developer.ProjectElements
{
    [AutoloadEquip(EquipType.Body)]
    public class DexArmourChestplate : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dex's Chestplate");
            Tooltip.SetDefault("Perfect for impersonating a modder!");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(platinum: 999);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }
    }
}
