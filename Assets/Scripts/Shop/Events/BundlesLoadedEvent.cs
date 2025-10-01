using System.Collections.Generic;
using Shop.Data;

namespace Shop.Events
{
    public class BundlesLoadedEvent
    {
        public IReadOnlyList<BundleData> Bundles { get; }

        public BundlesLoadedEvent(IReadOnlyList<BundleData> bundles)
        {
            Bundles = bundles;
        }
    }
}