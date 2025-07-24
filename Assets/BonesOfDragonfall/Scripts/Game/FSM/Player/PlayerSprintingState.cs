/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using SkyForge.FSM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerSprintingState : IState
    {
        private readonly int _playerId;
        private readonly float _playerSprintingSpeed;
        private readonly float _playerAirSpeed;
        private readonly float _dragMovement;
        private readonly float _maxPlayerSprintingSpeed;
        
        private readonly IPlayerService _playerService;
        
        private Vector2 _playerMoveDirection;
        private bool _playerInGround;
        
        public PlayerSprintingState(IPlayerService playerService, ReactiveProperty<Vector2> direction,ReactiveProperty<bool> playerInGround, PlayerSettings playerSettings, int playerId)
        {
            _playerService = playerService;
            _playerSprintingSpeed = playerSettings.playerSpeed * playerSettings.playerMultiplayerSprintingSpeed;
            _playerId = playerId;
            _playerAirSpeed = playerSettings.playerAirSpeed;
            _dragMovement = playerSettings.dragMovement;
            _maxPlayerSprintingSpeed = playerSettings.maxPlayerSpeed * playerSettings.playerMultiplayerSprintingSpeed;
            
            
            direction.Subscribe(newDirection => _playerMoveDirection =  newDirection);
            playerInGround.Subscribe(newPlayer => _playerInGround = newPlayer);
        }
        
        public void OnStart()
        {
            Debug.Log("playerSprinting");
            _playerService.ChangeMaxSpeed(_playerSprintingSpeed, _playerId);
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            _playerService.Move(_playerMoveDirection, _playerSprintingSpeed, _playerAirSpeed, _dragMovement, _playerInGround, _playerId);
        }

        public void OnExit()
        {
            
        }
    }
}