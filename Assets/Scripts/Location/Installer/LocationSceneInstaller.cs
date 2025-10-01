using Location.Services;
using VContainer.Unity;

namespace Assets.Scripts.Location.Installer
{
    public class LocationSceneInstaller : IStartable
    {
        private readonly LocationDomainService _locationService;

        public LocationSceneInstaller(LocationDomainService locationService)
        {
            _locationService = locationService;
        }

        public void Start()
        {
            _locationService.PublishCurrentState();
        }
    }
}
