using Shop.Services;
using VContainer.Unity;

namespace Shop.Installer
{
    public class ShopSceneInstaller : IStartable
    {
        private readonly ShopService _shopService;

        public ShopSceneInstaller(ShopService shopService)
        {
            _shopService = shopService;
        }

        public void Start()
        {
            _shopService.PublishCurrentState();
        }
    }
}
