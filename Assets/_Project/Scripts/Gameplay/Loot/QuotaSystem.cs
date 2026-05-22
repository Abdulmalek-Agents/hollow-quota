using UnityEngine;
using UnityEngine.Events;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace HollowQuota.Loot
{
    public class QuotaSystem : MonoBehaviour
    {
        [SerializeField] private int targetQuota = 1500;
        public int Target => targetQuota;
        public int Current { get; private set; }
        public UnityEvent<int, int> OnQuotaChanged;
        public UnityEvent OnQuotaMet;

        public void AddValue(int amount)
        {
            Current += amount;
            OnQuotaChanged?.Invoke(Current, targetQuota);
            if (Current >= targetQuota) OnQuotaMet?.Invoke();
        }
    }
}
