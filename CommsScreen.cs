using HarmonyLib;

namespace Explorers_Appeal_Refresh
{
    [HarmonyPatch(typeof(PLCommsScreen), "SelectHailTarget")]
    internal class CommsScreen
    {
        //Check if the mission has been accepted or not when the comms button is pressed
        static void Prefix(PLHailTarget inHailTarget)
        {
            if (inHailTarget is EAHailTarget)
            {
                (inHailTarget as EAHailTarget).RefreshOptions();
            }
        }
    }
}
