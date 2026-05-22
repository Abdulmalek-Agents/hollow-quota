using UnityEngine;
namespace HollowQuota.Loot
{
    [CreateAssetMenu(menuName = "Hollow Quota/Loot Item Data", fileName = "Loot_")]
    public class LootItemDataSO : ScriptableObject
    {
        public string itemId;
        public string displayName;
        public Sprite icon;
        public GameObject worldPrefab;
        public int minValue = 80;
        public int maxValue = 200;
        public float weightKg = 1f;
        public LootRarity rarity = LootRarity.Common;
    }
    public enum LootRarity { Common, Uncommon, Rare, Legendary }
}
