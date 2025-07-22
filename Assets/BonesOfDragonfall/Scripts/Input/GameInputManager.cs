/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public class GameInputManager : BaseInputManager, IPlayerInput
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
        
        private void OnPlayerCameraRotationReceived(Vector2 direction)
        {
            PlayerCameraRotationReceivedEvent?.Invoke(direction);
        }

        private void OnPlayerMovedReceived(Vector2 direction)
        {
            PlayerMovedReceivedEvent?.Invoke(direction);
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
    }
}