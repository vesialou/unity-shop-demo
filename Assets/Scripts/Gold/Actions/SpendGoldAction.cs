using Core;
using Gold.Services;
using UnityEngine;

namespace Gold.Actions
{
    [CreateAssetMenu(fileName = "SpendGoldAction", menuName = "Actions/Gold/Spend Gold")]
    public class SpendGoldAction : BaseActionScriptableObject
    {
        [SerializeField] private int _amount = 10;

        public override bool CanApply(IActionFactory factory)
        {
            var goldService = factory.Resolve<GoldService>();
            return goldService.CanSpend(_amount);
        }

        public override void Apply(IActionFactory factory)
        {
            var goldService = factory.Resolve<GoldService>();
            goldService.SpendGold(_amount);
        }
    }
}