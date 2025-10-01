using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Core;
using Shop.Data;

namespace Shop.Services
{
    public class PurchaseProcessor
    {
        private readonly IActionFactory _actionFactory;
        private const int PROCESSING_DELAY_SECONDS = 3;

        public PurchaseProcessor(IActionFactory actionFactory)
        {
            _actionFactory = actionFactory;
        }

        public async UniTask<bool> ProcessPurchaseAsync(BundleData bundle, CancellationToken cancellationToken)
        {
            try
            {
                Debug.Log($"[Purchase] Starting purchase of '{bundle.BundleName}'...");

                await UniTask.Delay(TimeSpan.FromSeconds(PROCESSING_DELAY_SECONDS), cancellationToken: cancellationToken);

                if (!bundle.CanBuy(_actionFactory))
                {
                    Debug.LogWarning($"[Purchase] Cannot buy '{bundle.BundleName}' insufficient resources after delay");
                    return false;
                }

                bundle.ExecutePurchase(_actionFactory);
                Debug.Log($"[Purchase] Successfully purchased '{bundle.BundleName}'");

                return true;
            }
            catch (OperationCanceledException)
            {
                Debug.Log($"[Purchase] Purchase of '{bundle.BundleName}' was cancelled");
                return false;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Purchase] Error during purchase of '{bundle.BundleName}': {ex.Message}");
                return false;
            }
        }
    }
}