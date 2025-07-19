/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Command;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerRotationCommandHandler : ICommandHandler<CmdPlayerRotation>
    {
        private readonly GameStateModel _gameStateModel;

        public PlayerRotationCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdPlayerRotation command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.PlayerId)) as IPlayerModel;
            
            if (player == null)
                return false;
            
            player.Rotation.Value *= Quaternion.AngleAxis(command.Direction.x * command.SensitivityX * Time.deltaTime, Vector3.up);
            
            player.CameraRotation.UpdateValue(-command.Direction.y * command.SensitivityY * Time.deltaTime);
            player.CameraRotation.Value = Mathf.Clamp(player.CameraRotation.Value, -80f, 90f);
            
            return true;
        }
    }
}