/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using System;

namespace BonesOfDragonfall
{
    public class PlayerInventoryKeyboardMapper : BaseInput, IPlayerInventoryInputMapper, IDisposable
    {
        public PlayerInventoryKeyboardMapper(IInputMap inputMap) : base(inputMap)
        {
            
        }

        public bool PlayerCloseInventoryPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerCloseInventoryPressedKeyboard();
        }

        public bool DisablePlayerInventoryInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.DisablePlayerInventoryInputKeyboard();
        }

        public void EnablePlayerInventoryInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            gameInputMap.EnablePlayerInventoryInputKeyboard();
        }

        public void Dispose()
        {
            
        }
    }
}