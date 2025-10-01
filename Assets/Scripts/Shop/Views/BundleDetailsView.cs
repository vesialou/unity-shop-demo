using Shop.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Shop.Views
{
    public class BundleDetailsView : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private BundleCardView _cardPrefab;
        [SerializeField] private Transform _cardsContainer;

        private SelectedBundleService _selectedBundleService;
        private IObjectResolver _resolver;

        [Inject]
        public void Construct(
            SelectedBundleService selectedBundleService,
           IObjectResolver resolver)
        {
            _selectedBundleService = selectedBundleService;
            _resolver = resolver;
        }

        private void Start()
        {
            if (_selectedBundleService.HasSelected())
            {
                var bundle = _selectedBundleService.GetSelected();

                var cardInstance = _resolver.Instantiate(_cardPrefab, _cardsContainer);
                cardInstance.SetBundleData(bundle);
                cardInstance.InfoButton.SetActive(false);
            }
            else
            {
                Debug.LogError("[BundleDetailsView] No bundle selected!");
            }
        }
    }
}
