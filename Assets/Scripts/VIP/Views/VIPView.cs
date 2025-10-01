using Core;
using Core.Events;
using Core.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VIP.Services;

namespace VIP.Views
{
    public class VIPView : PermanentSubscriptionView
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _vipText;
        [SerializeField] private Button _cheatButton;

        private EventBus _eventBus;
        private IActionFactory _actionFactory;

        [Inject]
        public void Construct(EventBus eventBus, IActionFactory actionFactory)
        {
            _eventBus = eventBus;
            _actionFactory = actionFactory;
            SubscribeOnce();
        }

        protected override void OnSubscribe()
        {
            _eventBus.Subscribe<VIPChangedEvent>(OnVIPChanged);
        }

        protected override void OnUnsubscribe()
        {
            _eventBus.Unsubscribe<VIPChangedEvent>(OnVIPChanged);
        }

        private void Start()
        {
            if (_cheatButton != null)
            {
                _cheatButton.onClick.AddListener(OnCheatButtonClicked);
            }
        }

        private void OnDestroy()
        {
            if (_cheatButton != null)
            {
                _cheatButton.onClick.RemoveListener(OnCheatButtonClicked);
            }
        }

        private void OnVIPChanged(VIPChangedEvent @event)
        {
            UpdateDisplay(@event.Seconds);
        }

        private void UpdateDisplay(int seconds)
        {
            if (_vipText != null)
            {
                _vipText.text = $"VIP: {seconds} сек";
            }
        }

        private void OnCheatButtonClicked()
        {
            var vipService = _actionFactory.Resolve<VIPService>();
            vipService.ResetVIPTime();
        }
    }
}