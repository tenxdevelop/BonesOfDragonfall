/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using SkyForge;

namespace BonesOfDragonfall
{
    public static class GameViewRegister
    {
        public static void RegisterViews(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();

            var uIRootViewPrefab = loadService.LoadPrefab<UIRootView>(LoadService.PREFAB_UI_UIROOT);
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            
            var uIRootView = loadService.CreateView(uIRootViewPrefab, uIRootViewModel);
            Object.DontDestroyOnLoad(uIRootView.gameObject);
        }
    }
}