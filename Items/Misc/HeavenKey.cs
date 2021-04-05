using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc
{
	public class HeavenKey : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Heavenly Key");
        }
        public override void SetDefaults()
		{
			//item.CloneDefaults(ItemID.GoldenKey);
			item.width = 14;
			item.height = 24;
			item.maxStack = 1;
		}
	}
}
