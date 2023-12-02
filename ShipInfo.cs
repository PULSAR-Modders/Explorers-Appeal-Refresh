using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Explorers_Appeal_Refresh
{
    [HarmonyPatch(typeof(PLShipInfo), "UpdateHailTargets")]
    internal class ShipInfo
    {
        static void Prefix(PLShipInfo __instance)
        {
            if (__instance != PLEncounterManager.Instance.PlayerShip) return;

            foreach (PLHailTarget target in PLHailTarget.AllHailTargets)
            {
                if (target is EAHailTarget) return;
            }

            GameObject gameObj = new GameObject("Explorers Appeal Comms");
            gameObj.AddComponent<EAHailTarget>();
            EAHailTarget.isCU = PLServer.Instance.CrewFactionID == 0;
        }
    }
}
