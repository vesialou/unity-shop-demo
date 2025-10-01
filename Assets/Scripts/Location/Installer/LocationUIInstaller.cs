using Assets.Scripts.Location.Installer;
using Core.LifetimeScope;
using Location.Views;
using VContainer;
using VContainer.Unity;

namespace Location.Installer
{
    public class LocationUIInstaller : MonoBehaviourInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            _ = builder.RegisterComponentInHierarchy<LocationView>();
            _ = builder.RegisterEntryPoint<LocationSceneInstaller>();
        }
    }
}