using Core.LifetimeScope;
using Health.Views;
using VContainer;
using VContainer.Unity;

namespace Health.Installer
{
    public class HealthUIInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.RegisterComponentInHierarchy<HealthView>();
            _ = builder.RegisterEntryPoint<HealthSceneInstaller>();
        }
    }
}