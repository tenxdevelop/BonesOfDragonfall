/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.FSM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerMagicCastState : IState
    {
        public ReactiveProperty<bool> IsReadyMagicCast { get; private set; }
        
        private readonly Coroutines _coroutine;
        private readonly IPlayerService _playerService;
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerMagicInput _playerMagicInput;

        private bool _isActivePlayerMovementBefore;
        
        public PlayerMagicCastState(IPlayerService playerService, Coroutines coroutine, IPlayerMagicInput playerMagicInput, IPlayerInput playerInput)
        {
            _coroutine = coroutine;
            _playerService = playerService;
            _playerMagicInput = playerMagicInput;
            _playerInput = playerInput;
            
            IsReadyMagicCast = new ReactiveProperty<bool>(true);
        }
        
        public void OnStart()
        {
            Debug.Log("Can magic cast");
            _playerMagicInput.EnablePlayerMagicCastInput();
            _isActivePlayerMovementBefore = _playerInput.DisablePlayerMovementInput();
            
            IsReadyMagicCast.Value = false;
            _coroutine.StartCoroutine(UpdateIsReadyMagicCast());
        }

        public void OnUpdate(float deltaTime)
        {
            if (_playerMagicInput.PlayerMagicCastFirePressed())
            {
                Debug.Log("cast element fire");
            }
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            
        }

        public void OnExit()
        {
            Debug.Log("Disable magic cast");
            _playerMagicInput.DisablePlayerMagicCastInput();
            
            if(_isActivePlayerMovementBefore)
                _playerInput.EnablePlayerMovementInput();
            
            IsReadyMagicCast.Value = false;
            _coroutine.StartCoroutine(UpdateIsReadyMagicCast());
        }
        
        private IEnumerator UpdateIsReadyMagicCast()
        {
            yield return new WaitForSeconds(0.3f);
            IsReadyMagicCast.Value = true;
        }
    }
}