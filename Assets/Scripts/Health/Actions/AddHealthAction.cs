using UnityEngine;
using Core;
using Health.Services;

namespace Health.Actions
{
    [CreateAssetMenu(fileName = "AddHealthAction", menuName = "Actions/Health/Add Health")]
    public class AddHealthAction : BaseActionScriptableObject
    {
        [SerializeField] private int _amount = 10;

        public override bool CanApply(IActionFactory factory)
        {
            // Добавление здоровья всегда доступно
            return true;
        }

        public override void Apply(IActionFactory factory)
        {
            var healthService = factory.Resolve<HealthService>();
            healthService.AddHealth(_amount);
        }
    }
}