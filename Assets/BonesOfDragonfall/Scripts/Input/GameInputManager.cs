/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public class GameInputManager : BaseInputManager, IPlayerInput, IPlayerInventoryInput, IInputManager, IPlayerMagicInput
    {
        public event Action<Vector2> PlayerMovedReceivedEvent;
        public event Action<Vector2> PlayerCameraRotationReceivedEvent;
        
        public GameInputManager() : base(new GameInputMap())
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            gameInputMap.DisablePlayerInventoryInputKeyboard();
            gameInputMap.DisablePlayerMagicCastInput();
        }

        public override void Init()
        {
            //Init player input
            var playerInputs = GetInputs<IPlayerInputMapper>();
            
            foreach (var playerInput in playerInputs)
            {
                playerInput.PlayerMovedReceivedEvent += OnPlayerMovedReceived;
                playerInput.PlayerCameraRotationReceivedEvent += OnPlayerCameraRotationReceived;
            }
        }
        
        public override void Dispose()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();
            
            foreach (var playerInput in playerInputs)
            {
                playerInput.PlayerMovedReceivedEvent -= OnPlayerMovedReceived;
                playerInput.PlayerCameraRotationReceivedEvent -= OnPlayerCameraRotationReceived;
            }
            
            base.Dispose();
        }

        public bool PlayerCloseInventoryPressed()
        {
            var playerInventoryInputs = GetInputs<IPlayerInventoryInputMapper>();
            foreach (var playerInventoryInput in playerInventoryInputs)
            {
                if (playerInventoryInput.PlayerCloseInventoryPressed())
                    return true;
            }
            return false;
        }

        public bool DisablePlayerInventoryInput()
        {
            var result = false;
            var playerInventoryInputs = GetInputs<IPlayerInventoryInputMapper>();
            foreach (var playerInventoryInput in playerInventoryInputs)
            {
                result = playerInventoryInput.DisablePlayerInventoryInput();
            }
            
            return result;
        }

        public void EnablePlayerInventoryInput()
        {
            var playerInventoryInputs = GetInputs<IPlayerInventoryInputMapper>();
            foreach (var playerInventoryInput in playerInventoryInputs)
            {
                playerInventoryInput.EnablePlayerInventoryInput();
            }
        }

        public bool PlayerJumpPressed()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();
            
            foreach (var playerInput in playerInputs)
            {
                if (playerInput.PlayerJumpPressed())
                    return true;
            }
            return false;
        }

        public bool PlayerSprintingPressed()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();
            
            foreach (var playerInput in playerInputs)
            {
                if (playerInput.PlayerSprintingPressed())
                    return true;
            }
            
            return false;
        }

        public bool PlayerCrouchPressed()
        {
            
            var playerInputs = GetInputs<IPlayerInputMapper>();
            
            foreach (var playerInput in playerInputs)
            {
                if (playerInput.PlayerCrouchPressed())
                    return true;
            }
            
            return false;
        }

        public bool DisablePlayerInput()
        {
            var result = false;
            var playerInputs = GetInputs<IPlayerInputMapper>();
            foreach (var playerInput in playerInputs)
            {
                result = playerInput.DisablePlayerInput();
            }

            return result;
        }

        public void EnablePlayerInput()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();
            foreach (var playerInput in playerInputs)
            {
                playerInput.EnablePlayerInput();
            }
        }

        public bool DisablePlayerMovementInput()
        {
            var result = false;
            var playerInputs = GetInputs<IPlayerInputMapper>();
            foreach (var playerInput in playerInputs)
            {
                result = playerInput.DisablePlayerMovementInput();
            }

            return result;
        }

        public void EnablePlayerMovementInput()
        {
            
            var playerInputs = GetInputs<IPlayerInputMapper>();
            foreach (var playerInput in playerInputs)
            {
                playerInput.EnablePlayerMovementInput();
            }
        }

        private void OnPlayerCameraRotationReceived(Vector2 direction)
        {
            PlayerCameraRotationReceivedEvent?.Invoke(direction);
        }

        private void OnPlayerMovedReceived(Vector2 direction)
        {
            PlayerMovedReceivedEvent?.Invoke(direction);
        }
        
        public void DisableInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            gameInputMap.DisableInput();
        }

        public void EnableInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            gameInputMap.EnableInput();
        }
        
        public bool PlayerInteractionPressed()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();

            foreach (var playerInput in playerInputs)
            {
                if (playerInput.PlayerInteractionPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerOpenInventoryPressed()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();

            foreach (var playerInput in playerInputs)
            {
                if (playerInput.PlayerOpenInventoryPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerStartMagicCastPressed()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();

            foreach (var playerInput in playerInputs)
            {
                if (playerInput.PlayerStartMagicCastPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastWaterPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastWaterPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastFirePressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastFirePressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastEarthPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastEarthPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastElectricPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastElectricPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastAirPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastAirPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastFrostPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastFrostPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastLightPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastLightPressed())
                    return true;
            }

            return false;
        }

        public bool PlayerMagicCastDarkPressed()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                if (playerMagicInput.PlayerMagicCastDarkPressed())
                    return true;
            }

            return false;
        }

        public bool DisablePlayerMagicCastInput()
        {
            var result = false;
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                result = playerMagicInput.DisablePlayerMagicCastInput();
            }
            return result;
        }

        public void EnablePlayerMagicCastInput()
        {
            var playerMagicInputs = GetInputs<IPlayerMagicInputMapper>();
            foreach (var playerMagicInput in playerMagicInputs)
            {
                playerMagicInput.EnablePlayerMagicCastInput();
            }
        }
    }
}