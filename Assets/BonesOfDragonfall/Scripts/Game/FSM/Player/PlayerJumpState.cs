/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.FSM;

namespace BonesOfDragonfall
{
    public class PlayerJumpState : IState
    {
        private int _playerId;
        private float _jumpForce;
        private IPlayerService _playerService;

        public PlayerJumpState(IPlayerService playerService, int playerId, float jumpForce)
        {
            _playerId = playerId;
            _jumpForce = jumpForce;
            _playerService = playerService;
        }
        
        public void OnStart()
        {
            _playerService.Jump(_jumpForce, _playerId);
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnPhysicsUpdate(float deltaTime)
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}