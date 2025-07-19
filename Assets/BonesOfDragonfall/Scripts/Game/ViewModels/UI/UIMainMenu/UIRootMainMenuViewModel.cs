/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public class UIRootMainMenuViewModel : IUIRootMainMenuViewModel
    {
        private readonly ApplicationService _applicationService;
        private readonly IMainMenuService _mainMenuService;
        
        public UIRootMainMenuViewModel(ApplicationService applicationService, IMainMenuService mainMenuService)
        {
            _applicationService = applicationService;
            _mainMenuService = mainMenuService;
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
        [ReactiveMethod]
        public void StartGame(object sender)
        {
             _mainMenuService.LoadGameplay();
        }
        
        [ReactiveMethod]
        public void QuitGame(object sender)
        {
            _applicationService.CloseGame();
        }
    }
}