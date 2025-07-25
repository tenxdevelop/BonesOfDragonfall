/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Services.ConsoleService;
using SkyForge.Reactive.Extension;
using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;
using System.Linq;

namespace BonesOfDragonfall
{
    public class UIRootGameplayViewModel : IUIRootGameplayViewModel
    {
        [SubViewModel(typeof(ConsoleServiceViewModel))]
        public IConsoleServiceViewModel ConsoleServiceViewModel { get; private set; }
        public ReactiveCollection<UIScreenView> HUDScreens { get; private set; } = new();
        public ReactiveCollection<UIScreenView> Popups { get; private set; } = new();

        private bool _isActiveMouseBefore;
        private float _timeScaleBefore;
        public UIRootGameplayViewModel(IConsoleServiceViewModel consoleServiceViewModel, IInputManager inputManager, ApplicationService applicationService)
        {
            ConsoleServiceViewModel = consoleServiceViewModel;
            ConsoleServiceViewModel.IsShowConsole.Subscribe(isActiveConsole =>
            {
                if (isActiveConsole)
                {
                    inputManager.DisableInput();
                    _timeScaleBefore = applicationService.StopTimeGame();
                    _isActiveMouseBefore = applicationService.ShowMouseCursor();
                }
                else
                {
                    inputManager.EnableInput();
                    
                    if(_timeScaleBefore != 0)
                        applicationService.StartTimeGame();
                    
                    if(!_isActiveMouseBefore)
                        applicationService.HideMouseCursor();
                }
            });
        }
        
        public void AttachHUDScreen(UIScreenView hudScreen)
        {
            HUDScreens.Add(hudScreen);
        }

        public void DetachHUDScreen(UIScreenView hudScreen)
        {
            var hudScreenRemoved = HUDScreens.FirstOrDefault(currentHudScreen => currentHudScreen.Equals(hudScreen));
            HUDScreens.Remove(hudScreenRemoved);
        }

        public void ClearHUDScreens()
        {
            HUDScreens.Clear();
        }

        public void AttachPopup(UIScreenView popup)
        {
            Popups.Add(popup);
        }

        public void DetachPopup(UIScreenView popup)
        {
            var popupRemoved = Popups.FirstOrDefault(currentPopup => currentPopup.Equals(popup));
            Popups.Remove(popupRemoved);
        }

        public void ClearPopups()
        {
            Popups.Clear();
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
        
    }
}