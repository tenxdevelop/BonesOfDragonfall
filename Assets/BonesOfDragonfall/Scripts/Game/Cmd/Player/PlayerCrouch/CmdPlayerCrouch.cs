/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdPlayerCrouch : ICommand
    {
        public readonly int PlayerId;
        public readonly float CrouchScale;

        public CmdPlayerCrouch(float crouchScale, int playerId)
        {
            CrouchScale = crouchScale;
            PlayerId = playerId;
        }
    }
}