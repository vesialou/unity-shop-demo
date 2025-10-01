using Core.LifetimeScope;
using VContainer;
using VContainer.Unity;
using VIP.Services;

namespace VIP.Installer
{
    public class VIPInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.Register<VIPService>(Lifetime.Singleton);
            _ = builder.RegisterEntryPoint<VIPDomainInitializer>();
        }
    }
}