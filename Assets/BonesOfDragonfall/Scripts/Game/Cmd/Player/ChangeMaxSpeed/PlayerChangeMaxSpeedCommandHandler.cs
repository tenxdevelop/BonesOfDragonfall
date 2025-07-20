/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using System.Linq;

namespace BonesOfDragonfall
{
    public class PlayerChangeMaxSpeedCommandHandler : ICommandHandler<CmdPlayerChangeMaxSpeed>
    {
        private GameStateModel _gameStateModel;

        public PlayerChangeMaxSpeedCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdPlayerChangeMaxSpeed command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as IPlayerModel;

            if (player is null)
                return false;
            
            player.MaxSpeed.Value = command.MaxSpeed;
            return true;
        }
    }
}