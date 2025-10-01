using UnityEngine;
using Core;
using Health.Services;

namespace Health.Actions
{
    [CreateAssetMenu(fileName = "SpendHealthAction", menuName = "Actions/Health/Spend Health")]
    public class SpendHealthAction : BaseActionScriptableObject
    {
        [SerializeField] private int _amount = 10;

        public override bool CanApply(IActionFactory factory)
        {
            var healthService = factory.Resolve<HealthService>();
            return healthService.CanSpend(_amount);
        }

        public override void Apply(IActionFactory factory)
        {
            var healthService = factory.Resolve<HealthService>();
            healthService.SpendHealth(_amount);
        }
    }
}