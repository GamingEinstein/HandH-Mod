using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HandHmod.Items.Misc
{
    public class MeshHeartt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mesh Heartt");
            Tooltip.SetDefault("Permanently increases maximum life by 30\nUp to 10 can be used");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.color = Color.Purple;
            item.width = 32;
            item.height = 32;
        }

        public override bool CanUseItem(Player player)
        {
            // Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
            // This check also prevents this item from being used before vanilla health upgrades are maxed out.
            return player.statLifeMax == 500 && player.GetModPlayer<HandHmodPlayer>().meshheart < HandHmodPlayer.maxMeshheart;
        }

        public override bool UseItem(Player player)
        {
            // Do not do this: player.statLifeMax += 2
            player.statLifeMax2 += 30;
            player.statLife += 30;
            if (Main.myPlayer == player.whoAmI)
            {
                // This spawns the green numbers showing the heal value and informs other clients as well.
                player.HealEffect(2, true);
            }
            // This is very important. This is what makes it permanent.
            player.GetModPlayer<HandHmodPlayer>().meshheart += 1;
            // This handles the 2 achievements related to using any life increasing item or getting to exactly 500 hp and 200 mp.
            // Ignored since our item is only useable after this achievement is reached
            // AchievementsHelper.HandleSpecialEvent(player, 2);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.VoidHeart>()); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Materials.IIVoidEssenceII>(), 10); ;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
