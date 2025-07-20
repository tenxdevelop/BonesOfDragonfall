/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerMoveCommandHandler : ICommandHandler<CmdPlayerMove>
    {
        private readonly GameStateModel _gameStateModel;

        public PlayerMoveCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }

        public bool Handle(CmdPlayerMove command)
        {
            var player =
                _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as
                    IPlayerModel;

            if (player is null)
                return false;

            var moveDirection = player.Rotation.Value * (Vector3.forward * command.Direction.y + Vector3.right * command.Direction.x);

            if (command.PlayerInGround)
            {
                player.DragMovement.Value = command.DragMovement;
                player.ForceMovement.Value = moveDirection.normalized * command.Speed;
            }
            else
            {
                player.DragMovement.Value = 0;
                player.ForceMovement.Value = moveDirection.normalized * command.Speed * command.AirSpeed;
            }
            
            return true;
        }
    }
}