/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIRootGameplayViewModel : IViewModel
    {
        ReactiveCollection<UIScreenView> HUDScreens { get; }
        
        ReactiveCollection<UIScreenView> Popups { get; }
        
        void AttachHUDScreen(UIScreenView hudScreen);
        
        void DetachHUDScreen(UIScreenView hudScreen);
        
        void ClearHUDScreens();
        
        void AttachPopup(UIScreenView popup);
        
        void DetachPopup(UIScreenView popup);
        
        void ClearPopups();
        
    }
}