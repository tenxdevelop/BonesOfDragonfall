/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace BonesOfDragonfall
{
    public interface IPlayerMagicInputMapper : IInput
    {
        bool PlayerMagicCastWaterPressed();

        bool PlayerMagicCastFirePressed();

        bool PlayerMagicCastEarthPressed();

        bool PlayerMagicCastElectricPressed();

        bool PlayerMagicCastAirPressed();

        bool PlayerMagicCastFrostPressed();

        bool PlayerMagicCastLightPressed();

        bool PlayerMagicCastDarkPressed();
        bool PlayerCastMagicPressed();

        bool DisablePlayerMagicCastInput();

        void EnablePlayerMagicCastInput();
    }
}