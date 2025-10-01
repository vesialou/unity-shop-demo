using Shop.Data;

namespace Shop.Events
{
    public class PurchaseCompletedEvent
    {
        public BundleData Bundle { get; }
        public bool Success { get; }

        public PurchaseCompletedEvent(BundleData bundle, bool success)
        {
            Bundle = bundle;
            Success = success;
        }
    }
}