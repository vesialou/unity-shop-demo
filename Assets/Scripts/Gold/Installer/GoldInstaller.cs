using Core.LifetimeScope;
using Gold.Services;
using VContainer;
using VContainer.Unity;

namespace Gold.Installer
{
    public class GoldInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.Register<GoldService>(Lifetime.Singleton);
            _ = builder.RegisterEntryPoint<GoldDomainInitializer>();
        }
    }
}