using Shop.Data;

namespace Shop.Events
{
    public class InfoButtonClickedEvent
    {
        public BundleData Bundle { get; }

        public InfoButtonClickedEvent(BundleData bundle)
        {
            Bundle = bundle;
        }
    }
}
