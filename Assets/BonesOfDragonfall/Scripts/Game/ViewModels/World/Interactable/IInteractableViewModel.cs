/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;

namespace BonesOfDragonfall
{
    public interface IInteractableViewModel : IViewModel
    {
        void Interact(object sender);
    }
}
