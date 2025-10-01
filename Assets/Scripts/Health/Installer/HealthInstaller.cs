using Core.LifetimeScope;
using Health.Services;
using VContainer;
using VContainer.Unity;

namespace Health.Installer
{
    public class HealthInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.Register<HealthService>(Lifetime.Singleton).AsSelf();
            _ = builder.RegisterEntryPoint<HealthDomainInitializer>();
        }
    }
}