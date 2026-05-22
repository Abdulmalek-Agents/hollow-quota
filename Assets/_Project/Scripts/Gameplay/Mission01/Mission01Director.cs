using UnityEngine;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace HollowQuota.MissionOne
{
    public class Mission01Director : MonoBehaviour
    {
        [SerializeField] private string missionId = "M01";
        [SerializeField] private GameObject vanArrivalCutscene;
        [SerializeField] private GameObject extractionZone;
        [SerializeField] private GameObject completionPanel;
        private IMissionService _m;
        private void Start()
        {
            _m = ServiceLocator.Get<IMissionService>();
            _m.OnMissionCompleted += C;
            if (vanArrivalCutscene) vanArrivalCutscene.SetActive(true);
            if (extractionZone) extractionZone.SetActive(false);
            Invoke(nameof(OpenExtraction), 8 * 60f);
        }
        private void OnDestroy() { if (_m != null) _m.OnMissionCompleted -= C; }
        private void OpenExtraction() { if (extractionZone) extractionZone.SetActive(true); }
        private void C(MissionDataSO m) { if (m.missionId == missionId && completionPanel) completionPanel.SetActive(true); }
    }
}
