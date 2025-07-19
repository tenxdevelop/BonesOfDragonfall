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

            var playerViewPrefab = loadService.LoadPrefab<PlayerView>(LoadService.PREFAB_WORLD_PLAYER);
            var playerViewModel = container.Resolve<IPlayerViewModel>();
            loadService.CreateView(playerViewPrefab, playerViewModel);
            
        }
    }
}