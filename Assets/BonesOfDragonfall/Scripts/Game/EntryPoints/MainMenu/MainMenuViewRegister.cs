/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;

namespace BonesOfDragonfall
{
    public static class MainMenuViewRegister
    {
        public static void RegisterViews(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();
            
            //clear ui screens
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            
            uIRootViewModel.ClearUIScreens();
            uIRootViewModel.ClearUIStaticScreens();
            
            var staticUIRootMainMenuViewPrefab = loadService.LoadPrefab<StaticUIRootMainMenuView>(LoadService.PREFAB_UI_STATIC_UIROOT_MAIN_MENU);
            var staticUIRootMainMenuView = loadService.CreateGameObject(staticUIRootMainMenuViewPrefab);
            uIRootViewModel.AttachUIStaticScreen(staticUIRootMainMenuView);

            var uIRootMainMenuViewModel = container.Resolve<IUIRootMainMenuViewModel>();
            var uIRootMainMenuViewPrefab = loadService.LoadPrefab<UIRootMainMenuView>(LoadService.PREFAB_UI_UIROOT_MAIN_MENU);
            var uIRootMainMenuView = loadService.CreateView(uIRootMainMenuViewPrefab, uIRootMainMenuViewModel);
            uIRootViewModel.AttachUIScreen(uIRootMainMenuView);
            
        }
    }
}