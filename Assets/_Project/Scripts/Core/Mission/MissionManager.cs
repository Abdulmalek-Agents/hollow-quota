using UnityEngine;
using System;
using System.Collections.Generic;
namespace InventixGames.Core.Mission
{
    public interface IMissionService { MissionDataSO CurrentMission { get; } event Action<MissionDataSO> OnMissionStarted; event Action<MissionDataSO> OnMissionCompleted; event Action<MissionObjective> OnObjectiveUpdated; void StartMission(string missionId); void ReportObjectiveProgress(string objectiveId, int delta = 1); bool IsObjectiveComplete(string objectiveId); void CompleteMission(); }
    public class MissionManager : MonoBehaviour, IMissionService
    {
        [SerializeField] private MissionDatabaseSO database;
        public MissionDataSO CurrentMission { get; private set; }
        public event Action<MissionDataSO> OnMissionStarted;
        public event Action<MissionDataSO> OnMissionCompleted;
        public event Action<MissionObjective> OnObjectiveUpdated;
        private readonly Dictionary<string, int> _p = new();
        public void StartMission(string id) { CurrentMission = database?.Get(id); if (CurrentMission == null) return; _p.Clear(); foreach (var o in CurrentMission.objectives) _p[o.objectiveId] = 0; OnMissionStarted?.Invoke(CurrentMission); if (!string.IsNullOrEmpty(CurrentMission.sceneName)) SceneLoader.LoadSceneAsync(CurrentMission.sceneName); }
        public void ReportObjectiveProgress(string id, int d = 1) { if (CurrentMission == null || !_p.ContainsKey(id)) return; var o = CurrentMission.objectives.Find(x => x.objectiveId == id); if (o == null) return; _p[id] = Mathf.Min(o.targetCount, _p[id] + d); OnObjectiveUpdated?.Invoke(o); if (Done()) CompleteMission(); }
        public bool IsObjectiveComplete(string id) { var o = CurrentMission?.objectives.Find(x => x.objectiveId == id); return o != null && _p.TryGetValue(id, out var c) && c >= o.targetCount; }
        public void CompleteMission() { if (CurrentMission == null) return; OnMissionCompleted?.Invoke(CurrentMission); if (ServiceLocator.TryGet<ISaveService>(out var s)) s.MarkMissionComplete(CurrentMission.missionId); }
        private bool Done() { foreach (var o in CurrentMission.objectives) { if (o.optional) continue; if (!_p.TryGetValue(o.objectiveId, out var c) || c < o.targetCount) return false; } return true; }
    }
}
