/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using SkyForge.Input;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class GameInputMap : BaseInputMap<GameInputSystem>
    {
        private bool _isActivePlayerInput = true;
        private bool _isActivePlayerInventoryInput = true;
        
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
        
        public void DisablePlayerInputKeyboard()
        {
            _isActivePlayerInput = false;
            OriginInputMap.PlayerInputMap.Disable();
        }

        public void EnablePlayerInputKeyboard()
        {
            _isActivePlayerInput = true;
            OriginInputMap.PlayerInputMap.Enable();
        }

        public void DisablePlayerInventoryInputKeyboard()
        {
            OriginInputMap.PlayerInventoryMap.Disable();
            _isActivePlayerInventoryInput = false;
        }

        public void EnablePlayerInventoryInputKeyboard()
        {
            OriginInputMap.PlayerInventoryMap.Enable();
            _isActivePlayerInventoryInput = true;
        }
        
        public bool PlayerOpenInventoryPressedKeyboard()
        {
            return OriginInputMap.PlayerInventoryMap.PlayerOpenInventoryKeyboard.triggered;
        }

        public void DisableInput()
        {
            OriginInputMap.Disable();
        }

        public void EnableInput()
        {
            if (_isActivePlayerInput)
            {
                OriginInputMap.PlayerInputMap.Enable();
            }

            if (_isActivePlayerInventoryInput)
            {
                OriginInputMap.PlayerInventoryMap.Enable();
            }
        }

        public bool PlayerInterationPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerInteractionKeyboard.triggered;

        }
    }
}