using System.Collections;
using UnityEngine;
using InventixGames.Core;
namespace HollowQuota.Director
{
    /// <summary>
    /// Master-client only. Every 60–90s, builds an event context and asks Claude for a 1–2 sentence Director line.
    /// Broadcasts to all clients via Photon RPC (extension point left for Photon).
    /// </summary>
    public class RadioDirector : MonoBehaviour
    {
        [SerializeField] private AICopilotPersonaSO directorPersona;
        [SerializeField] private float intervalMin = 60f, intervalMax = 90f;
        [SerializeField] private bool isMasterClient = true; // set by Photon launcher in real build
        private IAICopilotService _ai;

        private void Start()
        {
            _ai = ServiceLocator.Get<IAICopilotService>();
            if (isMasterClient) StartCoroutine(Loop());
        }
        private IEnumerator Loop()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));
                string ctx = BuildContext();
                _ai.Ask(directorPersona.systemPrompt, ctx, OnLineReceived);
            }
        }
        protected virtual string BuildContext()
        {
            // Override / inject runtime state here (player names, quota, monster proximity, etc.)
            return "Provide a single short, dryly-corporate radio comment for the Reclaimers.";
        }
        protected virtual void OnLineReceived(string line)
        {
            // In Photon build: BroadcastRpc to RadioOverlay UI on all clients.
            Debug.Log($"[Director] {line}");
        }
    }
}
