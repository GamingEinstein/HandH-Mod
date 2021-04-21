using Terraria;
using Terraria.ModLoader;

namespace HandHmod.Buffs
{
    public class SpiritStar : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Spirit Star");
			Description.SetDefault("The Spirit Star will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			HandHmodPlayer modPlayer = player.GetModPlayer<HandHmodPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.MightOfTheMinion>()] > 0)
			{
				modPlayer.MightOfTheMinion = true;
			}
			if (!modPlayer.MightOfTheMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}
