/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using SkyForge.FSM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerMovingState : IState
    {
        private readonly int _playerId;
        private readonly float _playerSpeed;
        private readonly float _playerAirSpeed;
        private readonly float _dragMovement;
        private readonly float _maxPlayerSpeed;
        
        private readonly IPlayerService _playerService;
        
        private Vector2 _playerMoveDirection;
        private bool _playerInGround;
        
        public PlayerMovingState(IPlayerService playerService, ReactiveProperty<Vector2> direction,ReactiveProperty<bool> playerInGround, PlayerSettings playerSettings, int playerId)
        {
            _playerService = playerService;
            _playerSpeed = playerSettings.playerSpeed;
            _playerId = playerId;
            _playerAirSpeed = playerSettings.playerAirSpeed;
            _dragMovement = playerSettings.dragMovement;
            _maxPlayerSpeed = playerSettings.maxPlayerSpeed;
            
            direction.Subscribe(newDirection => _playerMoveDirection =  newDirection);
            playerInGround.Subscribe(newPlayer => _playerInGround = newPlayer);
        }
        
        public void OnStart()
        {
            Debug.Log("playerMoving");
            _playerService.ChangeMaxSpeed(_maxPlayerSpeed, _playerId);
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            _playerService.Move(_playerMoveDirection, _playerSpeed, _playerAirSpeed, _dragMovement, _playerInGround, _playerId);
        }

        public void OnExit()
        {
            
        }
    }
}