using Core.LifetimeScope;
using Gold.Views;
using VContainer;
using VContainer.Unity;

namespace Gold.Installer
{
    public class GoldUIInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.RegisterComponentInHierarchy<GoldView>();
            _ = builder.RegisterEntryPoint<GoldSceneInstaller>();
        }
    }
}