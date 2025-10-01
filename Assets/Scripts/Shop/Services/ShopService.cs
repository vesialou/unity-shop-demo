using Shop.Data;
using Shop.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Services
{
    public class ShopService
    {
        private readonly List<BundleData> _availableBundles = new();
        private readonly EventBus _eventBus;

        public IReadOnlyList<BundleData> AvailableBundles => _availableBundles;

        public ShopService(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            var bundles = Resources.LoadAll<BundleData>("Bundles");
            _availableBundles.Clear();
            _availableBundles.Capacity = bundles.Length;

            for (var i = 0; i < bundles.Length; i++)
            {
                if (bundles[i].IsActive)
                {
                    _availableBundles.Add(bundles[i]);
                }
            }

            Debug.Log($"[Shop] Loaded {_availableBundles.Count} bundles");
            PublishCurrentState();
        }

        public void SetBundles(List<BundleData> bundles)
        {
            _availableBundles.Clear();

            if (bundles != null)
            {
                _availableBundles.Capacity = bundles.Count;
                for (var i = 0; i < bundles.Count; i++)
                {
                    _availableBundles.Add(bundles[i]);
                }
            }

            _eventBus.Publish(new BundlesLoadedEvent(_availableBundles));
        }

        public void PublishCurrentState()
        {
            _eventBus.Publish(new BundlesLoadedEvent(_availableBundles));
        }
    }
}