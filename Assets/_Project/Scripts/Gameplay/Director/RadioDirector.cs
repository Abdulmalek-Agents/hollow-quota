using System.Collections;
using UnityEngine;
using InventixGames.Core.Dialogue;

namespace HollowQuota.Director
{
    /// <summary>
    /// Master-client only. Picks Director lines from event-appropriate LineBankSO pools
    /// and broadcasts to all clients via Photon RPC (extension point left intact).
    /// v0.2: 100% hand-authored lines — see /Assets/_Project/Data/LineBanks/.
    /// </summary>
    public class RadioDirector : MonoBehaviour
    {
        [Header("Line banks (author 20–40 lines each)")]
        [SerializeField] private LineBankSO idleBank;       // generic mocking lines
        [SerializeField] private LineBankSO downedBank;     // a Reclaimer goes down
        [SerializeField] private LineBankSO bigLootBank;    // expensive object collected
        [SerializeField] private LineBankSO quotaHitBank;   // quota reached
        [SerializeField] private LineBankSO huddleBank;     // crew clumps too long

        [Header("Cadence")]
        [SerializeField] private float intervalMin = 60f, intervalMax = 90f;
        [SerializeField] private bool isMasterClient = true; // set by Photon launcher

        [Header("Audio (optional)")]
        [SerializeField] private AudioSource radioSource;

        private void Start() { if (isMasterClient) StartCoroutine(IdleLoop()); }

        private IEnumerator IdleLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));
                FireLine(idleBank);
            }
        }

        public void OnPlayerDowned(string playerName) => FireLine(downedBank, playerName);
        public void OnBigLootGrabbed() => FireLine(bigLootBank);
        public void OnQuotaHit() => FireLine(quotaHitBank);
        public void OnCrewHuddled() => FireLine(huddleBank);

        protected virtual void FireLine(LineBankSO bank, string subject = null)
        {
            if (bank == null) return;
            string line = bank.PickRandom(out var clip);
            if (!string.IsNullOrEmpty(subject)) line = line.Replace("{name}", subject);
            if (radioSource && clip) { radioSource.clip = clip; radioSource.Play(); }
            // In Photon build: BroadcastRpc(line, clipName) so every client renders the same Director line.
            Debug.Log($"[Director] {line}");
        }
    }
}
