using Shop.Data;
using Shop.Events;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Shop.Views
{
    public class BundleListView : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Transform _cardsContainer;
        [SerializeField] private BundleCardView _cardPrefab;

        private readonly List<BundleCardView> _spawnedCards = new();
        private EventBus _eventBus;
        private IObjectResolver _resolver;

        [Inject]
        public void Construct(EventBus eventBus, IObjectResolver resolver)
        {
            _eventBus = eventBus;
            _resolver = resolver;
            _eventBus.Subscribe<BundlesLoadedEvent>(OnBundlesLoaded);
        }

        private void OnDisable()
        {
            if (_eventBus != null)
            {
                _eventBus.Unsubscribe<BundlesLoadedEvent>(OnBundlesLoaded);
            }
        }

        private void OnBundlesLoaded(BundlesLoadedEvent e)
        {
            SpawnBundleCards(e.Bundles);
        }

        private void SpawnBundleCards(IReadOnlyList<BundleData> bundles)
        {
            for (var i = _spawnedCards.Count - 1; i >= 0; i--)
            {
                if (_spawnedCards[i] != null)
                {
                    Destroy(_spawnedCards[i].gameObject);
                }
            }
            _spawnedCards.Clear();

            foreach (var bundle in bundles)
            {
                var cardInstance = _resolver.Instantiate(_cardPrefab, _cardsContainer);
                cardInstance.SetBundleData(bundle);
                _spawnedCards.Add(cardInstance);
            }

            Debug.Log($"[BundleListView] Spawned {_spawnedCards.Count} cards");
        }
    }
}