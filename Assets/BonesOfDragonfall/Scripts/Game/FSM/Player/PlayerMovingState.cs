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
        private int _playerId;
        private float _playerSpeed;
        
        private IPlayerService _playerService;
        
        private Vector2 _playerMoveDirection;
        
        public PlayerMovingState(IPlayerService playerService, ReactiveProperty<Vector2> direction, float playerSpeed, int playerId)
        {
            _playerService = playerService;
            _playerSpeed = playerSpeed;
            _playerId = playerId;
            
            direction.Subscribe(newDirection => _playerMoveDirection =  newDirection);
        }
        
        public void OnStart()
        {
            Debug.Log("playerMoving");
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            _playerService.Move(_playerMoveDirection, _playerSpeed, _playerId);
        }

        public void OnExit()
        {
            
        }
    }
}