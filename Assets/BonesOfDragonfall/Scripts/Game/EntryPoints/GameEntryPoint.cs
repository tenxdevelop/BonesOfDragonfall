/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.SceneManagement;
using System.Collections;
using SkyForge.Extension;
using UnityEngine;
using SkyForge;


namespace BonesOfDragonfall
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        
        private DIContainer _rootContainer;
        private Coroutines _coroutine;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Start()
        {
            if(_instance is not null)
                throw new System.ApplicationException("GameEntryPoint is already running!");
            
            InitApplicationSettings();
            
            _instance = new GameEntryPoint();
            _instance.Run();
        }
        
        private static void InitApplicationSettings()
        {
            Application.targetFrameRate = 120;
        }
        
        private void Run()
        { 
            _rootContainer = new DIContainer();
             
            //Init coroutines
            _coroutine = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutine.gameObject);
            _rootContainer.RegisterInstance(_coroutine);
            
            GameServiceRegister.RegisterServices(_rootContainer);
            
            var sceneService = _rootContainer.Resolve<SceneService>();
            sceneService.LoadSceneEvent += OnLoadScene;
            
            var defaultMainMenuEnterParams = new MainMenuEnterParams();
            _coroutine.StartCoroutine(sceneService.LoadMainMenu(defaultMainMenuEnterParams));
        }

        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode, SceneEnterParams sceneEnterParams)
        {
            var sceneName = scene.name;
            switch (sceneName)
            {
                case SceneService.BOOTSTRAP_SCENE:
                    OnLoadBootstrapScene();
                    break;
                case SceneService.MAIN_MENU_SCENE:
                    _coroutine.StartCoroutine(OnLoadMainMenuScene(sceneEnterParams));
                    break;
                case SceneService.GAMEPLAY_SCENE:
                    _coroutine.StartCoroutine(OnLoadGameplayScene(sceneEnterParams));
                    break;
                default:
                    throw new System.ApplicationException("Invalid load scene name: " + sceneName);
            }
        }
        private void OnLoadBootstrapScene()
        {
            
        }

        private IEnumerator OnLoadMainMenuScene(SceneEnterParams sceneEnterParams)
        {
            var mainMenuContainer = new DIContainer(_rootContainer);

            var mainMenuEntryPoint = UnityExtension.GetEntryPoint<MainMenuEntryPoint>();
            
            yield return mainMenuEntryPoint.Initialization(mainMenuContainer, sceneEnterParams);

            mainMenuEntryPoint.Run();
            
        }

        private IEnumerator OnLoadGameplayScene(SceneEnterParams sceneEnterParams)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
