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
    public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
    {
        
        private SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams = new();
        private DIContainer _container;
        
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            _container =  parentContainer;
            
            var mainMenuEnterParams = sceneEnterParams.As<MainMenuEnterParams>();
            
            MainMenuServiceRegister.RegisterServices(_container, mainMenuEnterParams, _mainMenuExitParams);
            MainMenuViewModelRegister.RegisterViewModels(_container, mainMenuEnterParams);
            MainMenuViewRegister.RegisterViews(_container);
            
            Debug.Log("Init main menu");
            
            yield return null;
        }

        public IObservable<SceneExitParams> Run()
        { 
            return _mainMenuExitParams;
        }
    }
}