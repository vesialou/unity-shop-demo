using Core.GameFlow;
using Shop.Events;
using Shop.Services;
using System;
using VContainer.Unity;

namespace Shop.Controllers
{
    public class NavigationController : IStartable, IDisposable
    {
        private readonly EventBus _eventBus;
        private readonly GameFlowController _gameFlowController;
        private readonly SelectedBundleService _selectedBundleService;

        public NavigationController(
            EventBus eventBus,
            GameFlowController gameFlowController,
            SelectedBundleService selectedBundleService)
        {
            _eventBus = eventBus;
            _gameFlowController = gameFlowController;
            _selectedBundleService = selectedBundleService;
        }

        public void Start()
        {
            _eventBus.Subscribe<InfoButtonClickedEvent>(OnInfoButtonClicked);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<InfoButtonClickedEvent>(OnInfoButtonClicked);
        }

        private void OnInfoButtonClicked(InfoButtonClickedEvent @event)
        {
            _selectedBundleService.SetSelected(@event.Bundle);
            _gameFlowController.ShowBundleDetails();
        }
    }
}