using Core.Events;
using Core.Views;
using Gold.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Gold.Views
{
    public class GoldView : PermanentSubscriptionView
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _cheatButton;

        private EventBus _eventBus;
        private GoldService _goldService;

        [Inject]
        public void Construct(EventBus eventBus, GoldService goldService)
        {
            _eventBus = eventBus;
            _goldService = goldService;
            SubscribeOnce();
        }

        protected override void OnSubscribe()
        {
            _eventBus.Subscribe<GoldChangedEvent>(OnGoldChanged);
        }

        protected override void OnUnsubscribe()
        {
            _eventBus.Unsubscribe<GoldChangedEvent>(OnGoldChanged);
        }

        private void Start()
        {
            if (_cheatButton != null)
            {
                _cheatButton.onClick.AddListener(OnCheatButtonClicked);
            }

            UpdateDisplay(_goldService.GetCurrentGold());
        }

        private void OnDestroy()
        {
            if (_cheatButton != null)
            {
                _cheatButton.onClick.RemoveListener(OnCheatButtonClicked);
            }
        }

        private void OnGoldChanged(GoldChangedEvent @event)
        {
            UpdateDisplay(@event.NewValue);
        }

        private void UpdateDisplay(int gold)
        {
            if (_goldText != null)
            {
                _goldText.text = $"Золото: {gold}";
            }
        }

        private void OnCheatButtonClicked()
        {
            _goldService.AddGold(50);
        }
    }
}