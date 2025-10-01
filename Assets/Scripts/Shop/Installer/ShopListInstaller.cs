using Core.LifetimeScope;
using Shop.Controllers;
using Shop.Views;
using VContainer;
using VContainer.Unity;

namespace Shop.Installer
{
    public class ShopListInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.RegisterEntryPoint<NavigationController>(Lifetime.Singleton);

            _ = builder.RegisterComponentInHierarchy<BundleListView>().AsSelf();
            _ = builder.RegisterComponentInHierarchy<PurchaseBlockerView>().AsSelf();

            _ = builder.RegisterEntryPoint<ShopSceneInstaller>();

            
        }
    }
}