using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Core.GameFlow
{
    public class GameFlowController : IStartable, IDisposable
    {
        private const string _bundlesListScene = "BundlesListScene";
        private const string _bundleDetailsScene = "BundleDetailsScene";

        private string _currentScene;
        private bool _isSwitching;
        private CancellationTokenSource _cancellationToken;

        private CancellationTokenSource NewCts
        {
            get
            {
                _cancellationToken?.Cancel();
                _cancellationToken?.Dispose();
                _cancellationToken = new CancellationTokenSource();
                return _cancellationToken;
            }
        }

        public async void Start()
        {
            await LoadSceneAsync(_bundlesListScene, NewCts.Token);
        }

        public void ShowBundleDetails()
        {
            if (_isSwitching)
            {
                return;
            }

            SwitchScene(_bundleDetailsScene, NewCts.Token).Forget();
        }

        public void ShowBundlesList()
        {
            if (_isSwitching)
            {
                return;
            }

            SwitchScene(_bundlesListScene, NewCts.Token).Forget();
        }

        private async UniTaskVoid SwitchScene(string targetScene, CancellationToken ct)
        {
            _isSwitching = true;
            try
            {
                if (!string.IsNullOrEmpty(_currentScene))
                {
                    await SceneManager.UnloadSceneAsync(_currentScene).ToUniTask(cancellationToken: ct);
                }

                await LoadSceneAsync(targetScene, ct);
            }
            finally
            {
                _isSwitching = false;
            }
        }

        private async UniTask LoadSceneAsync(string sceneName, CancellationToken cancellationToken)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            await loadOp.ToUniTask(cancellationToken: cancellationToken);

            var scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogError($"Scene not valid or not loaded: {sceneName}");
                return;
            }

            var success = SceneManager.SetActiveScene(scene);
            if (!success)
            {
                Debug.LogError($"Failed to set active scene: {sceneName}");
                return;
            }

            await UniTask.WaitUntil(() => SceneManager.GetActiveScene() == scene, cancellationToken: cancellationToken);

            _currentScene = sceneName;
        }

        public void Dispose()
        {
            if (_cancellationToken != null)
            {
                _cancellationToken.Cancel();
                _cancellationToken.Dispose();
                _cancellationToken = null;
            }
        }
    }
}