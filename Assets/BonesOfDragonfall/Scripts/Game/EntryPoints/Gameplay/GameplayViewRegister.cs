/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameplayViewRegister
    {
        public static void RegisterViews(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();
            
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            
            uIRootViewModel.ClearUIScreens();
            uIRootViewModel.ClearUIStaticScreens();
            
            var uIRootGameplayViewPrefab = loadService.LoadPrefab<UIRootGameplayView>(LoadService.PREFAB_UI_UIROOT_GAMEPLAY);
            var uIRootGameplayViewModel = container.Resolve<IUIRootGameplayViewModel>();
            var uIRootGameplayView = loadService.CreateView(uIRootGameplayViewPrefab, uIRootGameplayViewModel);
            
            uIRootViewModel.AttachUIScreen(uIRootGameplayView);
            
            var uIPlayerInventoryViewPrefab = loadService.LoadPrefab<UIPlayerInventoryView>(LoadService.PREFAB_UI_PLAYER_INVENTORY);
            var uIPlayerInventoryViewModel = container.Resolve<IUIPlayerInventoryViewModel>();
            var uIPlayerInventoryView = loadService.CreateView(uIPlayerInventoryViewPrefab, uIPlayerInventoryViewModel);
            
            uIRootGameplayViewModel.AttachPopup(uIPlayerInventoryView);
            
            var uIRootPlayerHUDViewPrefab = loadService.LoadPrefab<UIRootPlayerHUDView>(LoadService.PREFAB_UI_UIROOT_PLAYER_HUD);
            var uIRootPlayerHUDViewModel = container.Resolve<IUIRootPlayerHUDViewModel>();
            var uIRootPlayerHUDView = loadService.CreateView(uIRootPlayerHUDViewPrefab, uIRootPlayerHUDViewModel);
            
            uIRootGameplayViewModel.AttachHUDScreen(uIRootPlayerHUDView);
            
            var playerViewPrefab = loadService.LoadPrefab<PlayerView>(LoadService.PREFAB_WORLD_PLAYER);
            var playerViewModel = container.Resolve<IPlayerViewModel>();
            loadService.CreateView(playerViewPrefab, playerViewModel);
            
        }
    }
}