
namespace Explorers_Appeal_Refresh
{
    internal class EAHailTarget : PLHailTarget
    {
        public static bool isCU = true;
        private static readonly string CUName = "Explorer's Appeal";
        private static readonly string WDName = "Surveyor Application";
        private static readonly string CUText = "Eldon Gatra: Welcome to Outpost 448. How may I assist you?";
        private static readonly string WDText = "Remhan Zesho: Welcome to the W.D. Intelligence Center. How can I help?";

        public override string GetCurrentDialogueLeft()
        {
            return isCU ? CUText : WDText;
        }

        public override string GetCurrentDialogueRight()
        {
            return string.Empty;
        }

        public override string GetName()
        {
            return (isCU ? CUName : WDName) + " (LONG RANGE)";
        }

        public override void Start()
        {
            base.Start();
            RefreshOptions();
        }

        public void RefreshOptions()
        {
            bool started = false;
            foreach (PLMissionBase mission in PLServer.Instance.AllMissions)
            {
                if (mission.MissionTypeID == 3109 || mission.MissionTypeID == 3111)
                {
                    started = true;
                    break;
                }
            }

            this.m_AllChoices.Clear();
            if (started)
            {
                this.m_AllChoices.Add(new PLHailChoice_SimpleCustom("End " + (isCU ? CUName : WDName), new PLHailChoiceDelegate(EndAppeal)));
            }
            else
            {
                this.m_AllChoices.Add(new PLHailChoice_SimpleCustom("Start " + (isCU ? CUName : WDName), new PLHailChoiceDelegate(StartAppeal)));
            }
            this.m_AllChoices.Add(new PLHailChoice_SimpleCustom("Close Transmission", new PLHailChoiceDelegate(CloseTransmission)));
        }

        private void StartAppeal(bool authority, bool local)
        {
            if (PhotonNetwork.isMasterClient)
            {
                PLServer.Instance.photonView.RPC("AttemptStartMissionOfTypeID", PhotonTargets.MasterClient, new object[]
                        {
                            (isCU ? 3109 : 3111),
                            false
                        });
                CloseTransmission(authority, local);
            }
        }

        private void EndAppeal(bool authority, bool local)
        {
            if (PhotonNetwork.isMasterClient)
            {
                foreach (PLMissionBase mission in PLServer.Instance.AllMissions)
                {
                    if (mission.MissionTypeID == 3109 || mission.MissionTypeID == 3111)
                    {
                        mission.Objectives[0].IsCompleted = true;
                        break;
                    }
                }
                CloseTransmission(authority, local);
            }
        }

        private void CloseTransmission(bool authority, bool local)
        {
            PLCommsScreen.SelectHailTarget(null, PLEncounterManager.Instance.PlayerShip);
        }
    }
}
