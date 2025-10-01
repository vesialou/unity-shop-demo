using Shop.Data;

namespace Shop.Events
{
    public class PurchaseStartedEvent
    {
        public BundleData Bundle { get; }

        public PurchaseStartedEvent(BundleData bundle)
        {
            Bundle = bundle;
        }
    }
}