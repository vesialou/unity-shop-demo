using Core;
using Core.Events;
using Core.Views;
using Shop.Data;
using Shop.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Shop.Views
{
    public class BundleCardView : PermanentSubscriptionView
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _buyButtonText;
        [SerializeField] private Button _infoButton;

        [Header("Bundle Data")]
        [SerializeField] private BundleData _bundleData;

        private IActionFactory _actionFactory;
        private EventBus _eventBus;
        private bool _isProcessing;

        public GameObject InfoButton => _infoButton.gameObject;

        [Inject]
        public void Construct(IActionFactory actionFactory, EventBus eventBus)
        {
            _actionFactory = actionFactory;
            _eventBus = eventBus;
            SubscribeOnce();
        }

        protected override void OnSubscribe()
        {
            _eventBus.Subscribe<ResourcesChangedEvent>(OnResourcesChangedEvent);
            _eventBus.Subscribe<PurchaseStartedEvent>(OnPurchaseStartedEvent);
            _eventBus.Subscribe<PurchaseCompletedEvent>(OnPurchaseCompletedEvent);
        }

        protected override void OnUnsubscribe()
        {
            _eventBus.Unsubscribe<ResourcesChangedEvent>(OnResourcesChangedEvent);
            _eventBus.Unsubscribe<PurchaseStartedEvent>(OnPurchaseStartedEvent);
            _eventBus.Unsubscribe<PurchaseCompletedEvent>(OnPurchaseCompletedEvent);
        }

        private void Start()
        {
            if (_bundleData == null)
            {
                Debug.LogError("[BundleCard] BundleData is not assigned!");
                return;
            }

            if (_nameText != null)
            {
                _nameText.text = _bundleData.BundleName;
            }

            if (_buyButton != null)
            {
                _buyButton.onClick.AddListener(OnBuyButtonClicked);
            }

            if (_infoButton != null)
            {
                _infoButton.onClick.AddListener(OnInfoButtonClicked);
            }

            SetIdleState();
        }

        private void OnDestroy()
        {
            if (_buyButton != null)
            {
                _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
            }

            if (_infoButton != null)
            {
                _infoButton.onClick.RemoveListener(OnInfoButtonClicked);
            }
        }

        private void OnBuyButtonClicked()
        {
            _eventBus.Publish(new BuyButtonClickedEvent(_bundleData));
        }

        private void OnInfoButtonClicked()
        {
            _eventBus.Publish(new InfoButtonClickedEvent(_bundleData));
        }

        private void OnResourcesChangedEvent(ResourcesChangedEvent _)
        {
            if (_isProcessing)
            {
                return;
            }

            SetIdleState();
        }

        private void OnPurchaseCompletedEvent(PurchaseCompletedEvent @event)
        {
            _isProcessing = false;
            SetIdleState();
        }

        private void OnPurchaseStartedEvent(PurchaseStartedEvent @event)
        {
            if (@event.Bundle.BundleName == _bundleData.BundleName)
            {
                _isProcessing = true;
                SetProcessingState();
            }
        }

        public void SetBundleData(BundleData bundleData)
        {
            _bundleData = bundleData;

            if (_nameText != null)
            {
                _nameText.text = _bundleData.BundleName;
            }

            SetIdleState();
        }

        private void SetIdleState()
        {
            if (_buyButton == null)
            {
                return;
            }

            var canBuy = _bundleData.CanBuy(_actionFactory);

            _buyButton.interactable = canBuy;
            if (_buyButtonText != null)
            {
                _buyButtonText.text = "Купить";
            }
        }

        private void SetProcessingState()
        {
            if (_buyButton == null)
            {
                return;
            }

            _buyButton.interactable = false;
            if (_buyButtonText != null)
            {
                _buyButtonText.text = "Обработка...";
            }
        }
    }
}