using UnityEngine;
using VContainer.Unity;

namespace Core.LifetimeScope
{
    public class CoreInitializer : IStartable
    {
        private readonly PlayerData _playerData;

        public CoreInitializer(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Start()
        {
            Debug.Log("Core domain initialized");
        }
    }
}