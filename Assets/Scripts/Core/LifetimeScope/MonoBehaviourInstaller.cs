using UnityEngine;
using VContainer;

namespace Core.LifetimeScope
{
    public abstract class MonoBehaviourInstaller : MonoBehaviour
    {
        public abstract void Install(IContainerBuilder builder);
    }
}