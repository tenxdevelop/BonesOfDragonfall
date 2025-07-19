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

        private DIContainer _container;
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            _container = parentContainer;

            var gameplayEnterParams = sceneEnterParams.As<GameplayEnterParams>();
            
            GameplayServiceRegister.RegisterServices(_container, gameplayEnterParams, _gameplayExitParams);
            GameplayViewModelRegister.RegisterViewModels(_container, gameplayEnterParams);
            GameplayViewRegister.RegisterViews(_container);
            
            yield return null;
        }

        public IObservable<SceneExitParams> Run()
        {
            return _gameplayExitParams;
        }
    }
}