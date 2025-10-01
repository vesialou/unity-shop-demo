using Core.GameFlow;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Shop.Views
{
    public class BackButtonView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private GameFlowController _gameFlowController;

        [Inject]
        public void Construct(GameFlowController gameFlowController)
        {
            _gameFlowController = gameFlowController;
        }

        private void Start()
        {
            if (_backButton != null)
            {
                _backButton.onClick.AddListener(OnBackButtonClicked);
            }
        }

        private void OnDisable()
        {
            if (_backButton != null)
            {
                _backButton.onClick.RemoveListener(OnBackButtonClicked);
            }
        }

        private void OnBackButtonClicked()
        {
            _gameFlowController.ShowBundlesList();
        }
    }
}