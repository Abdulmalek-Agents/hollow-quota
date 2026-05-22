using UnityEngine;
namespace HollowQuota.Loot
{
    public class LootItem : MonoBehaviour
    {
        [SerializeField] private LootItemDataSO data;
        public int RolledValue { get; private set; }
        public LootItemDataSO Data => data;
        private void Awake() { RolledValue = Random.Range(data.minValue, data.maxValue + 1); }
    }
}
