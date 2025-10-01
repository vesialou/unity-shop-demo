using Health.Services;
using VContainer.Unity;

namespace Health.Installer
{
    public class HealthSceneInstaller : IStartable
    {
        private readonly HealthService _healthService;

        public HealthSceneInstaller(HealthService healthService)
        {
            _healthService = healthService;
        }

        public void Start()
        {
            _healthService.PublishCurrentState();
        }
    }
}
