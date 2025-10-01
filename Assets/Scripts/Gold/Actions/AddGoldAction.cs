using Core;
using Gold.Services;
using UnityEngine;

namespace Gold.Actions
{
    [CreateAssetMenu(fileName = "AddGoldAction", menuName = "Actions/Gold/Add Gold")]
    public class AddGoldAction : BaseActionScriptableObject
    {
        [SerializeField] private int _amount = 10;

        public override bool CanApply(IActionFactory factory)
        {
            return true;
        }

        public override void Apply(IActionFactory factory)
        {
            var goldService = factory.Resolve<GoldService>();
            goldService.AddGold(_amount);
        }
    }
}