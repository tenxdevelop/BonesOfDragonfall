/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public class GameInputManager : BaseInputManager, IPlayerInput, IPlayerInventoryInput, IInputManager
    {
        public event Action<Vector2> PlayerMovedReceivedEvent;
        public event Action<Vector2> PlayerCameraRotationReceivedEvent;
        
        public GameInputManager() : base(new GameInputMap())
        {
            
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

        public bool PlayerOpenInventoryPressed()
        {
            var playerInventoryInputs = GetInputs<IPlayerInventoryInputMapper>();
            foreach (var playerInventoryInput in playerInventoryInputs)
            {
                if (playerInventoryInput.PlayerOpenInventoryPressed())
                    return true;
            }
            return false;
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

        public void DisablePlayerInput()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();
            foreach (var playerInput in playerInputs)
            {
                playerInput.DisablePlayerInput();
            }
        }

        public void EnablePlayerInput()
        {
            var playerInputs = GetInputs<IPlayerInputMapper>();
            foreach (var playerInput in playerInputs)
            {
                playerInput.EnablePlayerInput();
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
    }
}