/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIRootViewModel : IViewModel
    {
        ReactiveProperty<bool> IsOpenLoadingScreen { get; }
        
        ReactiveCollection<UIScreenView> StaticScreens { get; }
        ReactiveCollection<UIScreenView> Screens { get; }

        void AttachUIStaticScreen(UIScreenView uIStaticScreenView);
        
        void DetachUIStaticScreen(UIScreenView uIStaticScreenView);
        
        void ClearUIStaticScreens();
        
        void AttachUIScreen(UIScreenView uIScreenView);
        
        void DetachUIScreen(UIScreenView uIScreenView);
        
        void ClearUIScreens();
        
        void ShowLoadingScreen();

        void HideLoadingScreen();
    }
}