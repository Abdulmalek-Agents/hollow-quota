using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace InventixGames.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text quotaText, objectiveText, timerText, radioFeedText;
        [SerializeField] private Slider quotaProgress;
        private IMissionService _m;
        private void OnEnable() { _m = ServiceLocator.Get<IMissionService>(); _m.OnMissionStarted += S; _m.OnObjectiveUpdated += O; _m.OnMissionCompleted += C; }
        private void OnDisable() { if (_m == null) return; _m.OnMissionStarted -= S; _m.OnObjectiveUpdated -= O; _m.OnMissionCompleted -= C; }
        private void S(MissionDataSO m) { if (objectiveText && m.objectives.Count > 0) objectiveText.text = m.objectives[0].description; }
        private void O(MissionObjective o) { if (objectiveText) objectiveText.text = o.description; }
        private void C(MissionDataSO m) { if (objectiveText) objectiveText.text = "Quota met. Extract."; }
        public void OnDirectorLine(string line) { if (radioFeedText) radioFeedText.text = "[Director] " + line; }
    }
}
