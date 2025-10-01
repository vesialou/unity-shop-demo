using Health.Services;
using VContainer.Unity;

namespace Health.Installer
{
    public class HealthDomainInitializer : IStartable
    {
        private readonly HealthService _healthService;

        public HealthDomainInitializer(HealthService healthService)
        {
            _healthService = healthService;
        }

        public void Start()
        {
            _healthService.Initialize();
        }
    }
}