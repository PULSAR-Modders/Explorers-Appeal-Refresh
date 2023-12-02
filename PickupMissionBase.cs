using HarmonyLib;

namespace Explorers_Appeal_Refresh
{
    [HarmonyPatch(typeof(PLPickupMissionBase), "OnMissionSuccess")]
    internal class PickupMissionBase
    {
        //Remove the mission from the completed list so it can be accepted again
        static void Postfix(PLPickupMissionBase __instance)
        {
            if (__instance.MissionTypeID == 3109 || __instance.MissionTypeID == 3111) //3109 is CU Explorers Appeal, 3111 is WD Surveyor Application
            {
                PLServer.Instance.AllMissions.Remove(__instance);
            }
        }
    }
}
