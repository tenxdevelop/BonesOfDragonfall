/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using SkyForge.Input;

namespace BonesOfDragonfall
{
    public class GameInputMap : BaseInputMap<GameInputSystem>
    {
        private bool _isActivePlayerInput = true;
        private bool _isActivePlayerMovementInput = true;
        private bool _isActivePlayerInventoryInput;
        private bool _isActivePlayerMagicCastInput;
        
        public InputAction GetInputPlayerMovedKeyboard()
        {
            return OriginInputMap.PlayerMovementInput.PlayerMovementKeyboard;
        }

        public InputAction GetInputPlayerRotationCameraMouse()
        {
            return OriginInputMap.PlayerInputMap.PlayerRotationCameraMouse;
        }

        public bool PlayerJumpPressedKeyboard()
        {
            return OriginInputMap.PlayerMovementInput.PlayerJumpKeyboard.triggered;
        }

        public bool PlayerSprintPressedKeyboard()
        {
            return OriginInputMap.PlayerMovementInput.PlayerSprintingKeyboard.IsPressed();
        }

        public bool PlayerCrouchPressedKeyboard()
        {
            return OriginInputMap.PlayerMovementInput.PlayerCrouchKeyboard.triggered;
        }
        
        public bool DisablePlayerInputKeyboard()
        {
            var result = _isActivePlayerInput;
            _isActivePlayerInput = false;
            OriginInputMap.PlayerInputMap.Disable();
            return result;
        }
        
        public void EnablePlayerInputKeyboard()
        {
            _isActivePlayerInput = true;
            OriginInputMap.PlayerInputMap.Enable();
        }

        public bool DisablePlayerInventoryInputKeyboard()
        {
            var result =  _isActivePlayerInventoryInput;
            OriginInputMap.PlayerInventoryMap.Disable();
            _isActivePlayerInventoryInput = false;
            return result;
        }

        public void EnablePlayerInventoryInputKeyboard()
        {
            OriginInputMap.PlayerInventoryMap.Enable();
            _isActivePlayerInventoryInput = true;
        }
        
        public bool PlayerOpenInventoryPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerOpenInventoryKeyboard.triggered;
        }

        public bool PlayerCloseInventoryPressedKeyboard()
        {
            return OriginInputMap.PlayerInventoryMap.PlayerCloseInventoryKeyboard.triggered;
        }

        public bool PlayerStartMagicCastPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerStartMagicCastKeyboard.triggered;
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

            if (_isActivePlayerMovementInput)
            {
                OriginInputMap.PlayerMovementInput.Enable();
            }

            if (_isActivePlayerMagicCastInput)
            {
                OriginInputMap.PlayerMagicCastInput.Enable();
            }
        }

        public bool PlayerInteractionPressedKeyboard()
        {
            return OriginInputMap.PlayerInputMap.PlayerInteractionKeyboard.triggered;

        }

        public bool PlayerMagicCastWaterPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastWaterKeyboard.triggered;;
        }
        
        public bool PlayerMagicCastFirePressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastFireKeyboard.triggered;
        }

        public bool PlayerMagicCastEarthPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastEarthKeyboard.triggered;
        }

        public bool PlayerMagicCastElectricPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastElectricKeyboard.triggered;
        }

        public bool PlayerMagicCastAirPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastAirKeyboard.triggered;
        }

        public bool PlayerMagicCastFrostPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastFrostKeyboard.triggered;
        }

        public bool PlayerMagicCastLightPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastLightKeyboard.triggered;
        }

        public bool PlayerMagicCastDarkPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastDarkKeyboard.triggered;
        }

        public bool PlayerCastMagicPressedKeyboard()
        {
            return OriginInputMap.PlayerMagicCastInput.PlayerMagicCastMagicKeyboard.triggered;
        }
        
        public bool DisablePlayerMagicCastInput()
        {
            var result = _isActivePlayerMagicCastInput;
            _isActivePlayerMagicCastInput = false;
            OriginInputMap.PlayerMagicCastInput.Disable();
            return result;
        }

        public void EnablePlayerMagicCastInput()
        {
            _isActivePlayerMagicCastInput = true;
            OriginInputMap.PlayerMagicCastInput.Enable();
        }

        public bool DisablePlayerMovementInputKeyboard()
        {
            var result = _isActivePlayerMovementInput;
            _isActivePlayerMovementInput = false;
            OriginInputMap.PlayerMovementInput.Disable();
            return result;
        }

        public void EnablePlayerMovementInputKeyboard()
        {
            _isActivePlayerMovementInput = true;
            OriginInputMap.PlayerMovementInput.Enable();
        }
        
    }
}