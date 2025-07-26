/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using System;

namespace BonesOfDragonfall
{
    public class PlayerMagicKeyboardInputMapper : BaseInput, IPlayerMagicInputMapper, IDisposable
    {
        public PlayerMagicKeyboardInputMapper(IInputMap inputMap) : base(inputMap)
        {
        }

        public bool PlayerMagicCastWaterPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastWaterPressedKeyboard();
        }

        public bool PlayerMagicCastFirePressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastFirePressedKeyboard();
        }

        public bool PlayerMagicCastEarthPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastEarthPressedKeyboard();
        }

        public bool PlayerMagicCastElectricPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastElectricPressedKeyboard();
        }

        public bool PlayerMagicCastAirPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastAirPressedKeyboard();
        }

        public bool PlayerMagicCastFrostPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastFrostPressedKeyboard();
        }

        public bool PlayerMagicCastLightPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastLightPressedKeyboard();
        }

        public bool PlayerMagicCastDarkPressed()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.PlayerMagicCastDarkPressedKeyboard();
        }

        public bool DisablePlayerMagicCastInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            return gameInputMap.DisablePlayerMagicCastInput();
        }

        public void EnablePlayerMagicCastInput()
        {
            var gameInputMap = m_inputMap.As<GameInputMap>();
            gameInputMap.EnablePlayerMagicCastInput();
        }

        public void Dispose()
        {
            
        }
    }
}