using VContainer;

namespace Core.LifetimeScope
{
    public interface IDomainInstaller
    {
        void Install(IContainerBuilder builder);
    }
}