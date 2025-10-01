using Core;
using Core.LifetimeScope;

namespace Core
{
    public interface IAction
    {
        bool CanApply(IActionFactory factory);
        void Apply(IActionFactory factory);
    }
}