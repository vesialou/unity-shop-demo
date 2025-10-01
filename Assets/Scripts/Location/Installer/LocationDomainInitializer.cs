using Location.Services;
using VContainer.Unity;

namespace Location.Installer
{
    public class LocationDomainInitializer : IStartable
    {
        private readonly LocationDomainService _locationService;

        public LocationDomainInitializer(LocationDomainService locationService)
        {
            _locationService = locationService;
        }

        public void Start()
        {
            _locationService.Initialize();
        }
    }
}