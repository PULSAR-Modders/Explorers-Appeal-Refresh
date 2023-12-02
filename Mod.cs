using PulsarModLoader;

namespace Explorers_Appeal_Refresh
{
    public class Mod : PulsarMod
    {
        public static Mod Instance { get; private set; }

        public Mod()
        {
            Instance = this;
        }

        public override string Version => "0.0.3";

        public override string Author => "18107";

        public override string ShortDescription => "Allows the Explorers Appeal or Surveyor Application missions to be taken and completed multiple times";

        public override string Name => "Explorers Appeal Refresh";

        public override string ModID => "explorersappealrefresh";

        public override string HarmonyIdentifier()
        {
            return "id107.explorersappealrefresh";
        }
    }
}
