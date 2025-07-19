/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerService : IPlayerService
    {
        
        private readonly ICommandProcessor _commandProcessor;

        public PlayerService(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }
        
        public void Dispose()
        {
            
        }

        public void Move(Vector2 direction,  float speed, int playerId)
        {
            var command = new CmdPlayerMove(direction, speed, playerId);
            _commandProcessor.Process(command);
        }

        public void PlayerRotation(Vector2 direction, float sensitivityX, float sensitivityY, int playerId)
        {
            var command = new CmdPlayerRotation(direction, sensitivityX, sensitivityY, playerId);
            _commandProcessor.Process(command);
        }
    }
}