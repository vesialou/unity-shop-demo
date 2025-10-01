using Gold.Services;
using VContainer.Unity;

namespace Gold.Installer
{
    public class GoldSceneInstaller : IStartable
    {
        private readonly GoldService _goldService;

        public GoldSceneInstaller(GoldService goldService)
        {
            _goldService = goldService;
        }

        public void Start()
        {
            _goldService.PublishCurrentState();
        }
    }
}
