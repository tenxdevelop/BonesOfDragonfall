/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class LoadService : System.IDisposable
    {
        public const string PREFAB_UI_UIROOT = "Prefabs/UI/UIRoot";
        public const string PREFAB_UI_STATIC_UIROOT_MAIN_MENU = "Prefabs/UI/MainMenu/StaticUIRootMainMenu";
        public const string PREFAB_UI_UIROOT_MAIN_MENU = "Prefabs/UI/MainMenu/UIRootMainMenu";
        
        public const string PREFAB_WORLD_PLAYER = "Prefabs/World/Player/Player";
        
        public T LoadPrefab<T>(string prefabPath) where T : Object
        {
            var prefab = Resources.Load<T>(prefabPath);
            
            if (prefab is null)
            {
                Debug.LogError($"Failed to load prefab: {prefabPath}");
                throw new System.MethodAccessException("Failed to load prefab");
            }
            
            return prefab;
        }

        public T CreateGameObject<T>(T prefab, Transform parent = null) where T : Object
        {
            var newGameObject = Object.Instantiate(prefab, parent);
            return newGameObject;
        }

        public T CreateView<T>(T prefab, IViewModel viewModel, Transform parent = null) where T : View
        {
            var view = Object.Instantiate(prefab, parent);
            view.Bind(viewModel);
            
            return view;
        }
        
        public void Dispose()
        {
            
        }
    }
}