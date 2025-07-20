/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdCheckStandupPlayer : ICommand
    {
        public readonly int PlayerId;
        public readonly float PlayerHeight;
        
        public CmdCheckStandupPlayer(float playerHeight, int playerId)
        {
            PlayerId = playerId;
            PlayerHeight = playerHeight;
        }
    }
}