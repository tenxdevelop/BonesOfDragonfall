/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;
using SkyForge.FSM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public ReactiveProperty<float> MaxSpeed => _playerModel.MaxSpeed;
        public ReactiveProperty<Vector3> ForceMovement => _playerModel.ForceMovement;
        public ReactiveProperty<float> DragMovement => _playerModel.DragMovement;
        public ReactiveProperty<Vector3> JumpForce => _playerModel.JumpForce;
        public ReactiveProperty<Quaternion> Rotation => _playerModel.Rotation;
        public ReactiveProperty<float> CameraRotation => _playerModel.CameraRotation;
        public  ReactiveProperty<Vector3> ScaleCollider => _playerModel.ScaleCollider;
        
        private readonly IPlayerService _playerService;
        private readonly IPlayerModel _playerModel;
        private readonly IPlayerInput _playerInput;
        
        private readonly ReactiveProperty<Vector2> _playerMoveDirection = new();

        private readonly IFinalStateMachine _playerStateMachine;

        private readonly ReactiveProperty<bool> _playerInGround = new();

        private bool _isReadyCrouch;

        private bool _isReadyStandup;
        
        public PlayerViewModel(IPlayerModel playerModel, IPlayerService playerService, IPlayerInput playerInput, Coroutines coroutine)
        {
            _playerService = playerService;
            _playerModel = playerModel;
            _playerInput = playerInput;

            _playerInput.PlayerMovedReceivedEvent += OnPlayerMovedReceived;
            _playerInput.PlayerCameraRotationReceivedEvent += OnPlayerCameraRotationReceived;
            
            //Config player state machine
            _playerStateMachine = new FinalStateMachine();
            ConfigurePlayerStateMachine(coroutine);

            _isReadyCrouch = true;
            _isReadyStandup = true;
        }

        private void OnPlayerCameraRotationReceived(Vector2 direction)
        {
            _playerService.PlayerRotation(direction, 25, 20, _playerModel.UniqueId);
        }

        private void OnPlayerMovedReceived(Vector2 direction)
        {
            _playerMoveDirection.Value = direction;
        }

        public void Dispose()
        {
            _playerInput.PlayerMovedReceivedEvent -= OnPlayerMovedReceived;
            _playerInput.PlayerCameraRotationReceivedEvent -= OnPlayerCameraRotationReceived;
        }

        public void Update(float deltaTime)
        {
            _playerStateMachine.Update(deltaTime);
            _isReadyStandup = _playerService.CheckStandup(2f, _playerModel.UniqueId);
            UpdateInteractionPlayer();
        }

        [ReactiveMethod]
        public void UpdatePosition(object sender, Vector3 position)
        {
            _playerModel.Position.SetValue(sender, position);
        }
        
        public void PhysicsUpdate(float deltaTime)
        {
            _playerStateMachine.PhysicsUpdate(deltaTime);
        }
        
        [ReactiveMethod]
        public void PlayerInGround(object sender)
        {
            _playerInGround.Value = true;
        }
        
        [ReactiveMethod]
        public void PlayerNotInGround(object sender)
        {
            _playerInGround.Value = false;
        }

        private void ConfigurePlayerStateMachine(Coroutines coroutine)
        {
            var playerIdleState = new PlayerIdleState();
            var playerMovingState = new PlayerMovingState(_playerService, _playerMoveDirection, _playerInGround, 7 * 10 * 1.5f, 0.1f, 4f, _playerModel.UniqueId);
            var playerJumpState = new PlayerJumpState(_playerService, _playerModel.UniqueId, 20);
            var playerSprintingState = new PlayerSprintingState(_playerService, _playerMoveDirection, _playerInGround, 7 * 10 * 2f, 0.1f, 4f, _playerModel.UniqueId);
            var playerCrouchState = new PlayerCrouchState(_playerService, coroutine, 0.5f, 3.5f,_playerMoveDirection, _playerInGround, 7 * 10 * 2f, 0.1f, 4f, _playerModel.UniqueId);
            playerCrouchState.IsReadyCrouch.Subscribe(newValue => _isReadyCrouch = newValue);
            
            _playerStateMachine.RegisterState(playerIdleState);
            
            _playerStateMachine.AddTransition<PlayerIdleState>(playerMovingState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude > 0));
            _playerStateMachine.AddTransition<PlayerIdleState>(playerJumpState, new FuncPredicate(() => _playerInput.PlayerJumpPressed() && _playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerIdleState>(playerCrouchState, new FuncPredicate(() => _playerInput.PlayerCrouchPressed() && _playerInGround.Value && _isReadyCrouch));
            
            _playerStateMachine.AddTransition<PlayerMovingState>(playerIdleState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude == 0));
            _playerStateMachine.AddTransition<PlayerMovingState>(playerJumpState, new FuncPredicate(() => _playerInput.PlayerJumpPressed() && _playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerMovingState>(playerSprintingState, new FuncPredicate(() => _playerInput.PlayerSprintingPressed() && _playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerMovingState>(playerCrouchState, new FuncPredicate(() => _playerInput.PlayerCrouchPressed() && _playerInGround.Value && _isReadyCrouch));
            
            _playerStateMachine.AddTransition<PlayerJumpState>(playerIdleState, new FuncPredicate(() => true));
            
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerMovingState, new FuncPredicate(() => !_playerInput.PlayerSprintingPressed() || !_playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerIdleState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude == 0));
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerJumpState, new FuncPredicate(() => _playerInput.PlayerJumpPressed() && _playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerCrouchState, new FuncPredicate(() => _playerInput.PlayerCrouchPressed() && _playerInGround.Value && _isReadyCrouch));
            
            _playerStateMachine.AddTransition<PlayerCrouchState>(playerIdleState, new FuncPredicate(() => (_playerInput.PlayerCrouchPressed() || !_playerInGround.Value) && _isReadyCrouch && _isReadyStandup));
            
            _playerStateMachine.SetState(playerIdleState);
        }

        private void UpdateInteractionPlayer()
        {
            var interactableBinder = _playerService.CheckInteractionPlayer(3f, 2f, _playerModel.UniqueId);

            if (_playerInput.PlayerInteractionPressed() && interactableBinder != null)
            {
                interactableBinder.Interact();
            }
        }
    }
}