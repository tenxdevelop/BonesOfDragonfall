/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerJumpCommandHandler : ICommandHandler<CmdPlayerJump>
    {
        private GameStateModel _gameStateModel;

        public PlayerJumpCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdPlayerJump command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as IPlayerModel;

            if (player is null)
                return false;

            player.DragMovement.Value = 0f;
            player.JumpForce.Value = Vector3.up * command.Force;
            
            return true;
        }
    }
}