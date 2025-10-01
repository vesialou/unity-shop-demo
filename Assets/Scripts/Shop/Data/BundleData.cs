using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Data
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Shop/Bundle")]
    public class BundleData : ScriptableObject
    {
        [Header("IsActive")]
        [SerializeField] private bool _isActive = true;

        [Header("Bundle Info")]
        [SerializeField] private string _bundleName;

        [SerializeField] 
        private List<BaseActionScriptableObject> _costs = new();

        [SerializeField] 
        private List<BaseActionScriptableObject> _rewards = new();

        public string BundleName => _bundleName;
        public IReadOnlyList<BaseActionScriptableObject> CostsBundles => _costs;
        public IReadOnlyList<BaseActionScriptableObject> RewardsBundles => _rewards;

        public bool IsActive => _isActive;

        public bool CanBuy(IActionFactory factory)
        {
            foreach (var cost in _costs)
            {
                if (!cost.CanApply(factory))
                {
                    return false;
                }
            }
            return true;
        }

        public void ExecutePurchase(IActionFactory factory)
        {
            foreach (var cost in _costs)
            {
                cost.Apply(factory);
            }

            foreach (var reward in _rewards)
            {
                reward.Apply(factory);
            }
        }
    }
}