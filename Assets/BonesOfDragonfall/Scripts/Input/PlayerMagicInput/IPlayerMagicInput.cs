/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IPlayerMagicInput : IDisposable
    {
        bool PlayerMagicCastWaterPressed();

        bool PlayerMagicCastFirePressed();

        bool PlayerMagicCastEarthPressed();

        bool PlayerMagicCastElectricPressed();

        bool PlayerMagicCastAirPressed();

        bool PlayerMagicCastFrostPressed();

        bool PlayerMagicCastLightPressed();

        bool PlayerMagicCastDarkPressed();

        bool DisablePlayerMagicCastInput();

        void EnablePlayerMagicCastInput();
    }
}