using Shop.Data;

namespace Shop.Events
{
    public class BuyButtonClickedEvent
    {
        public BundleData Bundle { get; }

        public BuyButtonClickedEvent(BundleData bundle)
        {
            Bundle = bundle;
        }
    }
}