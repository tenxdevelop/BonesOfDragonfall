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

        public bool PlayerJumpPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerJumpKeyboard.triggered;
        }

        public bool PlayerSprintPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerSprintingKeyboard.IsPressed();
        }

        public bool PlayerCrouchPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerCrouchKeyboard.triggered;
        }
    }
}