using UnityEngine;
using UnityEngine.Events;
namespace HollowQuota.Player
{
    public class ReclaimerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        public int Current { get; private set; }
        public bool IsDowned { get; private set; }
        public UnityEvent OnDowned;
        public UnityEvent OnRevived;
        private void Awake() { Current = maxHealth; }
        public void TakeDamage(int a) { Current = Mathf.Max(0, Current - a); if (Current == 0 && !IsDowned) { IsDowned = true; OnDowned?.Invoke(); } }
        public void Revive() { Current = maxHealth / 2; IsDowned = false; OnRevived?.Invoke(); }
    }
}
