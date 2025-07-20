/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

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
        
        private readonly IPlayerService _playerService;
        private readonly IPlayerModel _playerModel;
        private readonly IPlayerInput _playerInput;
        
        private ReactiveProperty<Vector2> _playerMoveDirection = new();

        private IFinalStateMachine _playerStateMachine;

        private ReactiveProperty<bool> _playerInGround = new();
        
        public PlayerViewModel(IPlayerModel playerModel, IPlayerService playerService, IPlayerInput playerInput)
        {
            _playerService = playerService;
            _playerModel = playerModel;
            _playerInput = playerInput;

            _playerInput.PlayerMovedReceivedEvent += OnPlayerMovedReceived;
            _playerInput.PlayerCameraRotationReceivedEvent += OnPlayerCameraRotationReceived;
            
            //Config player state machine
            _playerStateMachine = new FinalStateMachine();

            var playerIdleState = new PlayerIdleState();
            var playerMovingState = new PlayerMovingState(_playerService, _playerMoveDirection, _playerInGround, 7 * 10 * 1.5f, 0.1f, 4f, _playerModel.UniqueId);
            var playerJumpState = new PlayerJumpState(_playerService, _playerModel.UniqueId, 20);
            var playerSprintingState = new PlayerSprintingState(_playerService, _playerMoveDirection, _playerInGround, 7 * 10 * 2f, 0.1f, 4f, _playerModel.UniqueId);
            
            _playerStateMachine.RegisterState(playerIdleState);
            
            _playerStateMachine.AddTransition<PlayerIdleState>(playerMovingState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude > 0));
            _playerStateMachine.AddTransition<PlayerIdleState>(playerJumpState, new FuncPredicate(() => _playerInput.PlayerJumpPressed() && _playerInGround.Value));
            
            _playerStateMachine.AddTransition<PlayerMovingState>(playerIdleState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude == 0));
            _playerStateMachine.AddTransition<PlayerMovingState>(playerJumpState, new FuncPredicate(() => _playerInput.PlayerJumpPressed() && _playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerMovingState>(playerSprintingState, new FuncPredicate(() => _playerInput.PlayerSprintingPressed() && _playerInGround.Value));
            
            _playerStateMachine.AddTransition<PlayerJumpState>(playerIdleState, new FuncPredicate(() => true));
            
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerMovingState, new FuncPredicate(() => !_playerInput.PlayerSprintingPressed() || !_playerInGround.Value));
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerIdleState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude == 0));
            _playerStateMachine.AddTransition<PlayerSprintingState>(playerJumpState, new FuncPredicate(() => _playerInput.PlayerJumpPressed() && _playerInGround.Value));
            
            _playerStateMachine.SetState(playerIdleState);
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
    }
}