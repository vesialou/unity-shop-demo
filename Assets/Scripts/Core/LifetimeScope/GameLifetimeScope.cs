using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Core.LifetimeScope
{
    public class GameLifetimeScope : VContainer.Unity.LifetimeScope
    {

        [Header("Domain Installers")]
        [SerializeField] private List<MonoBehaviourInstaller> _domainInstallers = new();

        protected override void Configure(IContainerBuilder builder)
        {
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