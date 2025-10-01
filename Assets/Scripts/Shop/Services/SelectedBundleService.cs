using Shop.Data;

namespace Shop.Services
{
    public class SelectedBundleService
    {
        private BundleData _selectedBundle;

        public void SetSelected(BundleData bundle)
        {
            _selectedBundle = bundle;
        }

        public BundleData GetSelected()
        {
            return _selectedBundle;
        }

        public bool HasSelected()
        {
            return _selectedBundle != null;
        }
    }
}
