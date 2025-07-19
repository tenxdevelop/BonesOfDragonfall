/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using SkyForge.Input;

namespace BonesOfDragonfall
{
    public class GameInputMap : BaseInputMap<GameInputSystem>
    {
        
        public InputAction GetInputPlayerMovedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerMovementKeyboard;
        }

        public InputAction GetInputPlayerRotationCameraMouse()
        {
            return OriginInputMap.PlayerInputMap.PlayerRotationCameraMouse;
        }
    }
}