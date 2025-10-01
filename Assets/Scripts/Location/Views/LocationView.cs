using Core;
using Core.Views;
using Location.Data;
using Location.Events;
using Location.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Location.Views
{
    public class LocationView : PermanentSubscriptionView
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _locationText;
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
            _eventBus.Subscribe<LocationChangedEvent>(OnLocationChanged);
        }

        protected override void OnUnsubscribe()
        {
            _eventBus.Unsubscribe<LocationChangedEvent>(OnLocationChanged);
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

        private void OnLocationChanged(LocationChangedEvent @event)
        {
            UpdateDisplay(@event.NewLocation);
        }

        private void UpdateDisplay(LocationType location)
        {
            if (_locationText != null)
            {
                var displayName = LocationDisplayNames.GetDisplayName(location);
                _locationText.text = $"Локация: {displayName}";
            }
        }

        private void OnCheatButtonClicked()
        {
            var locationService = _actionFactory.Resolve<LocationDomainService>();
            locationService.ResetToDefault();
        }
    }
}