/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using UnityEngine;
using SkyForge;

namespace BonesOfDragonfall
{
    public class GameplayEntryPoint : MonoBehaviour, IEntryPoint
    {
        private SingleReactiveProperty<GameplayExitParams> _gameplayExitParams = new();

        [SerializeField] private DoorView _doorView;

        private DIContainer _container;

        private Vector2 _playerMoveDirection = Vector2.zero;
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            _container = parentContainer;

            var gameplayEnterParams = sceneEnterParams.As<GameplayEnterParams>();
            
            GameplayServiceRegister.RegisterServices(_container, gameplayEnterParams, _gameplayExitParams);
            GameplayViewModelRegister.RegisterViewModels(_container, gameplayEnterParams);
            GameplayViewRegister.RegisterViews(_container);

            var doorViewModel = _container.Resolve<IDoorViewModel>();

            _doorView.Bind(doorViewModel);

            var applicationService = _container.Resolve<ApplicationService>();
            applicationService.HideMouseCursor();
            
            yield return null;
            
        }
        
        private void OnDisable()
        {
            _container?.Dispose();
        }
        
        public IObservable<SceneExitParams> Run()
        {
            return _gameplayExitParams;
        }
    }
}