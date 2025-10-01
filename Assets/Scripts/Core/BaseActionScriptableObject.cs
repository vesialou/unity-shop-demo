using UnityEngine;

namespace Core
{
    public abstract class BaseActionScriptableObject : ScriptableObject, IAction
    {
        public abstract bool CanApply(IActionFactory factory);
        public abstract void Apply(IActionFactory factory);
    }
}