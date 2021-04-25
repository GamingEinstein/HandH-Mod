using Terraria;
using Terraria.ModLoader;

namespace HandHmod.Backgrounds
{
    public class HeavenUgBgStyle : ModUgBgStyle
    {
        public override bool ChooseBgStyle()
        {
            return Main.LocalPlayer.GetModPlayer<HandHmodPlayer>().ZoneHeaven;
        }

        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/HeavenUG0");
            textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/HeavenUG1");
            textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/HeavenUG2");
            textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/HeavenUG3");
        }
    }
}