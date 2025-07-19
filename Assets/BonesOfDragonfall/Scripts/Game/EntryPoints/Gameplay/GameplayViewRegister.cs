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
        }
    }
}