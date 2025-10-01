using Core.Views;
using Shop.Events;
using UnityEngine;
using VContainer;

namespace Shop.Views
{
    public class PurchaseBlockerView : PermanentSubscriptionView
    {
        [SerializeField] private GameObject _blockPanel;

        private EventBus _eventBus;

        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
            SubscribeOnce();

            if (_blockPanel != null)
            {
                _blockPanel.SetActive(false);
            }
        }

        protected override void OnSubscribe()
        {
            _eventBus.Subscribe<PurchaseStartedEvent>(OnPurchaseStartedEvent);
            _eventBus.Subscribe<PurchaseCompletedEvent>(OnPurchaseCompletedEvent);
        }

        protected override void OnUnsubscribe()
        {
            _eventBus.Unsubscribe<PurchaseStartedEvent>(OnPurchaseStartedEvent);
            _eventBus.Unsubscribe<PurchaseCompletedEvent>(OnPurchaseCompletedEvent);
        }

        private void OnPurchaseStartedEvent(PurchaseStartedEvent @event)
        {
            if (_blockPanel != null)
            {
                _blockPanel.SetActive(true);
            }
        }

        private void OnPurchaseCompletedEvent(PurchaseCompletedEvent @event)
        {
            if (_blockPanel != null)
            {
                _blockPanel.SetActive(false);
            }
        }
    }
}