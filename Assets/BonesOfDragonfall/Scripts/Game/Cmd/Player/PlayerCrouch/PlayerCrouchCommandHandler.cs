/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;
using System.Linq;

namespace BonesOfDragonfall
{
    public class PlayerCrouchCommandHandler : ICommandHandler<CmdPlayerCrouch>
    {
        private GameStateModel _gameStateModel;

        public PlayerCrouchCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdPlayerCrouch command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as IPlayerModel;
            
            if(player is null)
                return false;
            
            player.ScaleCollider.Value = new Vector3(player.ScaleCollider.Value.x, command.CrouchScale,  player.ScaleCollider.Value.y);
            player.JumpForce.Value = Vector3.down * 5f;
            
            return true;
        }
    }
}