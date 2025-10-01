using Core;
using Health.Services;
using UnityEngine;

namespace Health.Actions
{
    [CreateAssetMenu(fileName = "SpendHealthPercentAction", menuName = "Actions/Health/Spend Health Percent")]
    public class SpendHealthPercentAction : BaseActionScriptableObject
    {
        [SerializeField][Range(0, 100)] private int _percent = 10;

        public override bool CanApply(IActionFactory factory)
        {
            var healthService = factory.Resolve<HealthService>();
            var amount = CalculateAmount(healthService.GetCurrentHealth());
            return healthService.CanSpend(amount);
        }

        public override void Apply(IActionFactory factory)
        {
            var healthService = factory.Resolve<HealthService>();
            var amount = CalculateAmount(healthService.GetCurrentHealth());
            healthService.SpendHealth(amount);
        }

        private int CalculateAmount(int currentHealth)
        {
            return Mathf.RoundToInt(currentHealth * _percent / 100f);
        }
    }
}