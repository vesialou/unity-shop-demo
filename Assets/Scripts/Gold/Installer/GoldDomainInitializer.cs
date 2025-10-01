using Gold.Services;
using VContainer.Unity;

namespace Gold.Installer
{
    public class GoldDomainInitializer : IStartable
    {
        private readonly GoldService _goldService;

        public GoldDomainInitializer(GoldService goldService)
        {
            _goldService = goldService;
        }

        public void Start()
        {
            _goldService.Initialize();
        }
    }
}