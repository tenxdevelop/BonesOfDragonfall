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

        public bool PlayerOpenInventoryPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerOpenInventoryPressedKeyboard();
        }

        public void Dispose()
        {
            
        }
    }
}