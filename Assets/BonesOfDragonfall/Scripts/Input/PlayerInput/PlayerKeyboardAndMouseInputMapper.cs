/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using SkyForge.Input;
using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public class PlayerKeyboardAndMouseInputMapper : BaseInput, IPlayerInputMapper, IDisposable
    {
        public event Action<Vector2> PlayerMovedReceivedEvent;
        public event Action<Vector2> PlayerCameraRotationReceivedEvent;
        
        public PlayerKeyboardAndMouseInputMapper(IInputMap inputMap) : base(inputMap)
        {
            var gameInputMap = inputMap.As<GameInputMap>();
            
            gameInputMap.GetInputPlayerMovedKeyboard().performed += OnPlayerMovedKeyboard;
            gameInputMap.GetInputPlayerMovedKeyboard().canceled += OnPlayerMovedKeyboard;
            
            gameInputMap.GetInputPlayerRotationCameraMouse().performed += OnPlayerRotationCameraMouse;
        }
        
        public void Dispose()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            
            gameInputMap.GetInputPlayerMovedKeyboard().performed -= OnPlayerMovedKeyboard;
            gameInputMap.GetInputPlayerMovedKeyboard().canceled -= OnPlayerMovedKeyboard;
            
            gameInputMap.GetInputPlayerRotationCameraMouse().performed -= OnPlayerRotationCameraMouse;
        }
        
        public bool PlayerJumpPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerJumpPressedKeyboard();
        }
        
        public bool PlayerSprintingPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerSprintPressedKeyboard();
        }
        
        public bool PlayerCrouchPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerCrouchPressedKeyboard();
        }

        public void DisablePlayerInput()
        {
            var gameInputMap =  m_inputMap.As<GameInputMap>();
            gameInputMap.DisablePlayerInputKeyboard();
        }

        public void EnablePlayerInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            gameInputMap.EnablePlayerInputKeyboard();
        }

        private void OnPlayerMovedKeyboard(InputAction.CallbackContext context)
        {
            PlayerMovedReceivedEvent?.Invoke(context.ReadValue<Vector2>());
        }
        
        private void OnPlayerRotationCameraMouse(InputAction.CallbackContext context)
        {
            PlayerCameraRotationReceivedEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public bool PlayerInteractionPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerInterationPressedKeyboard();
        }
    }
}