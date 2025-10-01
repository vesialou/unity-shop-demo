using UnityEngine;

namespace Core.Views
{
    public abstract class PermanentSubscriptionView : MonoBehaviour
    {
        private bool _isSubscribed;

        protected void SubscribeOnce()
        {
            if (_isSubscribed)
            {
                return;
            }

            OnSubscribe();
            _isSubscribed = true;
        }

        private void OnDisable()
        {
            if (_isSubscribed)
            {
                OnUnsubscribe();
                _isSubscribed = false;
            }
        }

        protected abstract void OnSubscribe();
        protected abstract void OnUnsubscribe();
    }
}