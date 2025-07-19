/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IUIRootMainMenuViewModel : IViewModel
    {
        void StartGame(object sender);
        
        void QuitGame(object sender);
    }
}