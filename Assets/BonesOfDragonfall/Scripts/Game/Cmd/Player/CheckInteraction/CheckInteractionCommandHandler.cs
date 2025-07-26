/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;
using System.Linq;

namespace BonesOfDragonfall
{
    public class CheckInteractionCommandHandler : ICommandHandler<CmdCheckInteraction>
    {

        private GameStateModel _gameStateModel;

        public CheckInteractionCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }

        public bool Handle(CmdCheckInteraction command)
        {
            var player = _gameStateModel.Entities.FirstOrDefault(entity => command.PlayerId.Equals(entity.UniqueId)) as IPlayerModel;

            if (player == null)
                return false;

            var origin = player.Position.Value + new Vector3(0, command.PlayerHeight, 0);
            var direction = player.Rotation.Value * Quaternion.AngleAxis(player.CameraRotation.Value, Vector3.right) * Vector3.forward;

            var ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out var hitInfo, command.DistansInteraction))
            {
                var interactableBinder = hitInfo.transform.GetComponent<InteractableBinder>();
                command.SetInteractableBinder(interactableBinder);
                return true;
            }

            return false;
        }
    }
}
