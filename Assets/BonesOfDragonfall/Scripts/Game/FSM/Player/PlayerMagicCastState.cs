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
        private readonly IUIRootPlayerHUDViewModel _uIRootPlayerHUDViewModel;
        private bool _isActivePlayerMovementBefore;
        
        public PlayerMagicCastState(IPlayerService playerService, Coroutines coroutine, IPlayerMagicInput playerMagicInput, IPlayerInput playerInput, IUIRootPlayerHUDViewModel uIRootPlayerHUDViewModel)
        {
            _coroutine = coroutine;
            _playerService = playerService;
            _playerMagicInput = playerMagicInput;
            _playerInput = playerInput;
            _uIRootPlayerHUDViewModel = uIRootPlayerHUDViewModel;
            
            IsReadyMagicCast = new ReactiveProperty<bool>(true);
        }
        
        public void OnStart()
        {
            _playerMagicInput.EnablePlayerMagicCastInput();
            _isActivePlayerMovementBefore = _playerInput.DisablePlayerMovementInput();
            _uIRootPlayerHUDViewModel.ShowMagicHUD();
            IsReadyMagicCast.Value = false;
            _coroutine.StartCoroutine(UpdateIsReadyMagicCast());
        }

        public void OnUpdate(float deltaTime)
        {
            if (_playerMagicInput.PlayerMagicCastFirePressed())
            {
                _playerService.AddMagicCastElement(MagicElementType.Fire, 10, 5, 1);
            }
            else if (_playerMagicInput.PlayerMagicCastWaterPressed())
            {
                _playerService.AddMagicCastElement(MagicElementType.Water, 10, 5, 1);
            }
            else if (_playerMagicInput.PlayerCastMagicPressed())
            {
                _playerService.ResetMagicCastElements(1);
            }
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            
        }

        public void OnExit()
        {
            _playerMagicInput.DisablePlayerMagicCastInput();
            
            if(_isActivePlayerMovementBefore)
                _playerInput.EnablePlayerMovementInput();
            
            _uIRootPlayerHUDViewModel.HideMagicHUD();
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