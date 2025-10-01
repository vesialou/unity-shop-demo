using Core;
using Shop.Events;
using Shop.Services;
using System;
using System.Threading;
using VContainer.Unity;

namespace Shop.Controllers
{
    public class PurchaseController : IStartable, IDisposable
    {
        private readonly EventBus _eventBus;
        private readonly PurchaseProcessor _purchaseProcessor;
        private readonly IActionFactory _actionFactory;

        private CancellationTokenSource _purchaseCts;
        private bool _isProcessing;

        public PurchaseController(
            EventBus eventBus,
            PurchaseProcessor purchaseProcessor,
            IActionFactory actionFactory)
        {
            _eventBus = eventBus;
            _purchaseProcessor = purchaseProcessor;
            _actionFactory = actionFactory;
        }

        public void Start()
        {
            _eventBus.Subscribe<BuyButtonClickedEvent>(OnBuyButtonClicked);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<BuyButtonClickedEvent>(OnBuyButtonClicked);
            _purchaseCts?.Cancel();
            _purchaseCts?.Dispose();
        }

        private async void OnBuyButtonClicked(BuyButtonClickedEvent @event)
        {
            if (_isProcessing)
            {
                return;
            }

            _isProcessing = true;
            var bundle = @event.Bundle;
            if (!bundle.CanBuy(_actionFactory))
            {
                UnityEngine.Debug.LogWarning($"[PurchaseController] Cannot buy '{bundle.BundleName}' - insufficient resources");
                _isProcessing = false;
                return;
            }

            _purchaseCts?.Cancel();
            _purchaseCts?.Dispose();
            _purchaseCts = new CancellationTokenSource();

            _eventBus.Publish(new PurchaseStartedEvent(bundle));

            try
            {
                var success = await _purchaseProcessor.ProcessPurchaseAsync(bundle, _purchaseCts.Token);
                _eventBus.Publish(new PurchaseCompletedEvent(bundle, success));
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"[PurchaseController] Unexpected error: {ex}");
                _eventBus.Publish(new PurchaseCompletedEvent(bundle, false));
            }
            finally
            {
                _isProcessing = false;
            }
        }
    }
}