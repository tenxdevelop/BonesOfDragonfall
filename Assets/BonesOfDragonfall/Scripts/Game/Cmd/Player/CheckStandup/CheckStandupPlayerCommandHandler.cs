/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;
using System.Linq;

namespace BonesOfDragonfall
{
    public class CheckStandupPlayerCommandHandler : ICommandHandler<CmdCheckStandupPlayer>
    {
        
        private GameStateModel _gameStateModel;

        public CheckStandupPlayerCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdCheckStandupPlayer command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as IPlayerModel;

            if (player is null)
                return false;

            var result = Physics.Raycast(player.Position.Value, Vector3.up, command.PlayerHeight * 0.5f + 0.4f);

            return !result;
        }
    }
}