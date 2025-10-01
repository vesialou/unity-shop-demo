using Core.LifetimeScope;
using Shop.Views;
using VContainer;
using VContainer.Unity;

namespace Shop.Installer
{
    public class ShopDetailsInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.RegisterComponentInHierarchy<PurchaseBlockerView>().AsSelf();
            _ = builder.RegisterComponentInHierarchy<BundleDetailsView>().AsSelf();
            _ = builder.RegisterComponentInHierarchy<BackButtonView>().AsSelf();
        }
    }
}
