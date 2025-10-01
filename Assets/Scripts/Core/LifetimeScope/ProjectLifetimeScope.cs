using Core.GameFlow;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.LifetimeScope
{
    public class ProjectLifetimeScope : VContainer.Unity.LifetimeScope
    {
        [Header("Domain Installers")]
        [SerializeField] private List<MonoBehaviourInstaller> _domainInstallers = new();
        protected override void Configure(IContainerBuilder builder)
        {
            _ = builder.RegisterEntryPoint<GameFlowController>().AsSelf();
            _ = builder.Register<EventBus>(Lifetime.Singleton);
            _ = builder.Register<PlayerData>(Lifetime.Singleton);
            _ = builder.RegisterEntryPoint<CoreInitializer>();
            _ = builder.Register<IActionFactory, ActionFactory>(Lifetime.Singleton);
            RunInstallers(builder);
        }
        private void RunInstallers(IContainerBuilder builder)
        {
            foreach (var installer in _domainInstallers)
            {
                if (installer != null)
                {
                    installer.Install(builder);
                    Debug.Log($"Installed domain: {installer.GetType().Name}");
                }
                else
                {
                    Debug.LogWarning("Null installer in domain installers list!");
                }
            }
        }
    }
}