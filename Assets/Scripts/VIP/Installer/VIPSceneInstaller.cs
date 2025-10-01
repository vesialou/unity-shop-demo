using VContainer.Unity;
using VIP.Services;

namespace VIP.Installer
{
    public class VIPSceneInstaller : IStartable
    {
        private readonly VIPService _vipService;

        public VIPSceneInstaller(VIPService vipService)
        {
            _vipService = vipService;
        }

        public void Start()
        {
            _vipService.PublishCurrentState();
        }
    }
}
