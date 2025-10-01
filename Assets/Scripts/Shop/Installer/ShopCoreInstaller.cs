using Core.LifetimeScope;
using Shop.Controllers;
using Shop.Services;
using VContainer;
using VContainer.Unity;

namespace Shop.Installer
{
    public class ShopCoreInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.Register<ShopService>(Lifetime.Singleton);
            _ = builder.Register<PurchaseProcessor>(Lifetime.Singleton);
            _ = builder.RegisterEntryPoint<PurchaseController>(Lifetime.Singleton);
            _ = builder.Register<SelectedBundleService>(Lifetime.Singleton);

            _ = builder.RegisterEntryPoint<ShopCoreInitializer>();
        }
    }
}
