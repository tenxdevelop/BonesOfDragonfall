/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdPlayerChangeMaxSpeed : ICommand
    {
        public readonly float MaxSpeed;
        public readonly int PlayerId;

        public CmdPlayerChangeMaxSpeed(float maxSpeed, int playerId)
        {
            MaxSpeed = maxSpeed;
            PlayerId = playerId;
        }
    }
}