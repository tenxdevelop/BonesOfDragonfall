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
        public ReactiveProperty<Vector3> ForceMovement => _playerModel.ForceMovement;
        public ReactiveProperty<Quaternion> Rotation => _playerModel.Rotation;
        public ReactiveProperty<float> CameraRotation => _playerModel.CameraRotation;
        
        private readonly IPlayerService _playerService;
        private readonly IPlayerModel _playerModel;
        private readonly IPlayerInput _playerInput;
        
        private ReactiveProperty<Vector2> _playerMoveDirection = new();

        private IFinalStateMachine _playerStateMachine;
        
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
            var playerMovingState = new PlayerMovingState(_playerService, _playerMoveDirection, 7 * 10, _playerModel.UniqueId);
            
            _playerStateMachine.RegisterState(playerIdleState);
            _playerStateMachine.AddTransition<PlayerIdleState>(playerMovingState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude > 0));
            _playerStateMachine.AddTransition<PlayerMovingState>(playerIdleState, new FuncPredicate(() => _playerMoveDirection.Value.magnitude == 0));
            
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

       
    }
}