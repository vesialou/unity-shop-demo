using Core.LifetimeScope;
using VContainer;
using VContainer.Unity;
using VIP.Views;

namespace VIP.Installer
{
    public class VIPUIInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.RegisterComponentInHierarchy<VIPView>();
            _ = builder.RegisterEntryPoint<VIPSceneInstaller>();
        }
    }
}