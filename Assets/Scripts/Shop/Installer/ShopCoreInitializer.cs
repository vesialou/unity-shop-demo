using Shop.Services;
using VContainer.Unity;

namespace Shop.Installer
{
    public class ShopCoreInitializer : IStartable
    {
        private readonly ShopService _shopService;

        public ShopCoreInitializer(ShopService shopService)
        {
            _shopService = shopService;
        }

        public void Start()
        {
            _shopService.Initialize();
        }
    }
}