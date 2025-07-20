/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdPlayerJump : ICommand
    {
        public readonly float Force;
        public readonly int PlayerId;

        public CmdPlayerJump(float force, int playerId)
        {
            Force = force;
            PlayerId = playerId;
        }
    }
}