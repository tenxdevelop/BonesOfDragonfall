/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.FSM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerCrouchState : IState
    {
        public ReactiveProperty<bool> IsReadyCrouch { get; private set; }
        
        private readonly IPlayerService _playerService;
        private readonly Coroutines _coroutine;
        
        private readonly int _playerId;
        private readonly float _maxSpeed;
        private readonly float _playerCrouchScale;
        
        private readonly float _playerSpeed;
        private readonly float _playerAirSpeed;
        private readonly float _dragMovement;
        
        private Vector2 _playerMoveDirection;
        private bool _playerInGround;
        
        public PlayerCrouchState(IPlayerService playerService, Coroutines coroutines, float playerCrouchScale, float maxSpeed, 
            ReactiveProperty<Vector2> direction, ReactiveProperty<bool> playerInGround, float playerSpeed, 
            float playerAirSpeed, float dragMovement, int playerId)
        {
            _playerService = playerService;
            
            _playerId =  playerId;
            _maxSpeed = maxSpeed;
            _playerCrouchScale = playerCrouchScale;
            _coroutine = coroutines;
            
            _playerSpeed =  playerSpeed;
            _dragMovement = dragMovement;
            _playerAirSpeed = playerAirSpeed;
            
            IsReadyCrouch = new ReactiveProperty<bool>(true);
            
            direction.Subscribe(newDirection => _playerMoveDirection =  newDirection);
            playerInGround.Subscribe(newPlayer => _playerInGround = newPlayer);
        }
        
        public void OnStart()
        {
            _playerService.PlayerCrouch(_playerCrouchScale, _playerId);
            _playerService.ChangeMaxSpeed(_maxSpeed, _playerId);
            
            IsReadyCrouch.Value = false;
            _coroutine.StartCoroutine(UpdateIsCrouch());
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            if (_playerMoveDirection.magnitude > 0)
            {
                _playerService.Move(_playerMoveDirection, _playerSpeed, _playerAirSpeed, _dragMovement, _playerInGround, _playerId);
            }
        }

        public void OnExit()
        {
            _playerService.PlayerStandup(_playerId);
            
            IsReadyCrouch.Value = false;
            _coroutine.StartCoroutine(UpdateIsCrouch());
        }

        private IEnumerator UpdateIsCrouch()
        {
            yield return new WaitForSeconds(0.5f);
            IsReadyCrouch.Value = true;
        }
    }
}