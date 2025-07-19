/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public class MainMenuService : IMainMenuService
    {

        private SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams;

        public MainMenuService(SingleReactiveProperty<MainMenuExitParams> mainMenuExitParams)
        {
            _mainMenuExitParams = mainMenuExitParams;
        }
        
        public void LoadGameplay()
        {
            var gameplayEnterParams = new GameplayEnterParams();
            _mainMenuExitParams.Value = new MainMenuExitParams(gameplayEnterParams);
        }
        
        public void Dispose()
        {
            
        }
    }
}