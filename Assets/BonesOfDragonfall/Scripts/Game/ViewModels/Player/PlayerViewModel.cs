/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public ReactiveProperty<Vector3> ForceMovement => _playerModel.ForceMovement;
        public ReactiveProperty<Quaternion> Rotation => _playerModel.Rotation;
        public ReactiveProperty<float> CameraRotation => _playerModel.CameraRotation;

        private readonly IPlayerModel _playerModel;
        private readonly IPlayerService _playerService;
        private readonly IPlayerInput _playerInput;
        
        private Vector2 _playerMoveDirection = Vector2.zero;
        public PlayerViewModel(IPlayerModel playerModel, IPlayerService playerService, IPlayerInput playerInput)
        {
            _playerModel = playerModel;
            _playerService = playerService;
            _playerInput = playerInput;

            _playerInput.PlayerMovedReceivedEvent += OnPlayerMovedReceived;
            _playerInput.PlayerCameraRotationReceivedEvent += OnPlayerCameraRotationReceived;
        }

        private void OnPlayerCameraRotationReceived(Vector2 direction)
        {
            _playerService.PlayerRotation(direction, 25, 20, _playerModel.UniqueId);
        }

        private void OnPlayerMovedReceived(Vector2 direction)
        {
            _playerMoveDirection = direction;
        }

        public void Dispose()
        {
            _playerInput.PlayerMovedReceivedEvent -= OnPlayerMovedReceived;
            _playerInput.PlayerCameraRotationReceivedEvent -= OnPlayerCameraRotationReceived;
        }

        public void Update(float deltaTime)
        {
            _playerService.Move(_playerMoveDirection, 16, _playerModel.UniqueId);
        }

        [ReactiveMethod]
        public void UpdatePosition(object sender, Vector3 position)
        {
            _playerModel.Position.SetValue(sender, position);
        }
        
        public void PhysicsUpdate(float deltaTime)
        {
            
        }

       
    }
}