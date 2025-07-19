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
        
        private void OnPlayerCameraRotationReceived(Vector2 direction)
        {
            PlayerCameraRotationReceivedEvent?.Invoke(direction);
        }

        private void OnPlayerMovedReceived(Vector2 direction)
        {
            PlayerMovedReceivedEvent?.Invoke(direction);
        }
    }
}