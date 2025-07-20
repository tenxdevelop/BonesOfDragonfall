/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdPlayerStandup : ICommand
    {
        public readonly int PlayerId;

        public CmdPlayerStandup(int playerId)
        {
            PlayerId = playerId;
        }
    }
}