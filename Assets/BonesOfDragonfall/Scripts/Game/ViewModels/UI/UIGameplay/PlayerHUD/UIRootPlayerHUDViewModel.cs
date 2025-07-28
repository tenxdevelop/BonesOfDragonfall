/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public class UIRootPlayerHUDViewModel : IUIRootPlayerHUDViewModel
    {
        public ReactiveProperty<float> MaxHealthPoints => _playerModel.MaxHealthPoint;
        
        public ReactiveProperty<float> CurrentHealthPoints => _playerModel.HealthPoint;

        public ReactiveProperty<float> MaxMagicPoints => _playerModel.MaxMagicPoint;

        public ReactiveProperty<float> CurrentMagicPoints => _playerModel.MagicPoint;
        
        private readonly IPlayerModel _playerModel;
        
        public UIRootPlayerHUDViewModel(IPlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
    }
}