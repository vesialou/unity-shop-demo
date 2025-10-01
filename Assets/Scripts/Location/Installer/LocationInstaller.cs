using Core.LifetimeScope;
using Location.Services;
using VContainer;
using VContainer.Unity;

namespace Location.Installer
{
    public class LocationInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.Register<LocationDomainService>(Lifetime.Singleton);
            _ = builder.RegisterEntryPoint<LocationDomainInitializer>();
        }
    }
}