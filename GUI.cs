using PulsarModLoader.CustomGUI;
using UnityEngine;

namespace Explorers_Appeal_Refresh
{
    internal class GUI : ModSettingsMenu
    {
        public override void Draw()
        {
            GUILayout.Space(20);
            if (!PhotonNetwork.isMasterClient)
            {
                GUILayout.Label("Not Host");
                return;
            }

            if (GUILayout.Button("Fix Appeal"))
            {
                foreach (PLMissionBase mission in PLServer.Instance.AllMissions)
                {
                    //3109 is CU Explorers Appeal, 3111 is WD Surveyor Application
                    if ((mission.MissionTypeID == 3109 || mission.MissionTypeID == 3111) &&
                        (mission.Abandoned || mission.Ended))
                    {
                        PLServer.Instance.AllMissions.Remove(mission);
                    }
                }
            }
        }

        public override string Name()
        {
            return Mod.Instance.Name;
        }
    }
}
