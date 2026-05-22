using UnityEngine;
using UnityEngine.UI;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace InventixGames.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MissionDatabaseSO database;
        [SerializeField] private Button hostButton, joinButton, quitButton;
        private void Start() { hostButton.onClick.AddListener(OnHost); joinButton.onClick.AddListener(OnJoin); quitButton.onClick.AddListener(OnQuit); }
        private void OnHost() { /* Photon: create room, then load M1 via Photon scene sync */ if (database.missions.Count > 0) ServiceLocator.Get<IMissionService>().StartMission(database.missions[0].missionId); }
        private void OnJoin() { /* Photon: join random room */ }
        private void OnQuit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
