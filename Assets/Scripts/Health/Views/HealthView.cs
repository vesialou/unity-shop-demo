using Core;
using Core.Events;
using Core.Views;
using TMPro;
using UnityEngine;
using VContainer;

namespace Health.Views
{
    public class HealthView : PermanentSubscriptionView
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private UnityEngine.UI.Button _cheatButton;

        private IActionFactory _actionFactory;
        private EventBus _eventBus;

        [Inject]
        public void Construct(EventBus eventBus, IActionFactory actionFactory)
        {
            _eventBus = eventBus;
            _actionFactory = actionFactory;
            SubscribeOnce();
        }

        protected override void OnSubscribe()
        {
            _eventBus.Subscribe<HealthChangedEvent>(OnHealthChanged);
        }

        protected override void OnUnsubscribe()
        {
            _eventBus.Unsubscribe<HealthChangedEvent>(OnHealthChanged);
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

        private void OnHealthChanged(HealthChangedEvent @event)
        {
            if (_healthText != null)
            {
                _healthText.text = $"Жизни: {@event.NewValue}";
            }
        }

        private void OnCheatButtonClicked()
        {
            _actionFactory.Resolve<Health.Services.HealthService>()
                          .AddHealth(50);
        }
    }
}