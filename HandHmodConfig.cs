using Terraria.ModLoader.Config;

namespace HandHmod
{
    public class HandHmodConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;


        [Label("Disable Example Wings Item")]

        [Tooltip("Prevents Loading the ExampleWings item. Requires a Reload")]

        [ReloadRequired]
        public bool DisableExampleWings { get; set; }

    }
}
