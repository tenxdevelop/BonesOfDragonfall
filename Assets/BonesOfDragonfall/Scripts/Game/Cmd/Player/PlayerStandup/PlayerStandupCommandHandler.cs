/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;
using System.Linq;

namespace BonesOfDragonfall
{
    public class PlayerStandupCommandHandler : ICommandHandler<CmdPlayerStandup>
    {
        
        private GameStateModel _gameStateModel;

        public PlayerStandupCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdPlayerStandup command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as IPlayerModel;

            if (player is null)
                return false;

            player.ScaleCollider.Value = new Vector3(1, 1, 1);
            return true;
        }
    }
}