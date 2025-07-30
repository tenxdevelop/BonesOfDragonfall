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

        public void Move(Vector2 direction, float speed, float airSpeed, float dragMovement, bool playerInGround, int playerId)
        {
            var command = new CmdPlayerMove(direction, speed, airSpeed, dragMovement, playerInGround, playerId);
            _commandProcessor.Process(command);
        }

        public void PlayerRotation(Vector2 direction, float sensitivityX, float sensitivityY, int playerId)
        {
            var command = new CmdPlayerRotation(direction, sensitivityX, sensitivityY, playerId);
            _commandProcessor.Process(command);
        }
        
        public void Jump(float jumpForce, int playerId)
        {
            var command = new CmdPlayerJump(jumpForce, playerId);
            _commandProcessor.Process(command);
        }

        public void ChangeMaxSpeed(float maxSpeed, int playerId)
        {
            var command = new CmdPlayerChangeMaxSpeed(maxSpeed, playerId);
            _commandProcessor.Process(command);
        }

        public void PlayerCrouch(float crouchScale, int playerId)
        {
            var command = new CmdPlayerCrouch(crouchScale, playerId);
            _commandProcessor.Process(command);
        }

        public void PlayerStandup(int playerId)
        {
            var command = new CmdPlayerStandup(playerId);
            _commandProcessor.Process(command);
        }

        public bool CheckStandup(float playerHeight, int playerId)
        {
            var command = new CmdCheckStandupPlayer(playerHeight, playerId);
            return _commandProcessor.Process(command);
        }

        public IInteractableBinder CheckInteractionPlayer(float distanceInteraction, float playerHeight, int playerId)
        {
            var command = new CmdCheckInteraction(distanceInteraction, playerHeight, playerId);
            _commandProcessor.Process(command);

            return command.InteractableBinder;
        }

        public void AddMagicCastElement(MagicElementType magicElementType, float costOfMagic, float power, int playerId)
        {
            var command = new CmdAddMagicCastElement(playerId, magicElementType, costOfMagic, power);
            _commandProcessor.Process(command);
        }

        public void ResetMagicCastElements(int playerId)
        {
            var command = new CmdResetMagicCast(playerId);
            _commandProcessor.Process(command);
        }
    }
}