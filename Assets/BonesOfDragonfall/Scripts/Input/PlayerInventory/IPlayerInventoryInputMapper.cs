/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace BonesOfDragonfall
{
    public interface IPlayerInventoryInputMapper : IInput
    {
        public bool PlayerCloseInventoryPressed();
        public bool DisablePlayerInventoryInput();
        public void EnablePlayerInventoryInput();
    }
}