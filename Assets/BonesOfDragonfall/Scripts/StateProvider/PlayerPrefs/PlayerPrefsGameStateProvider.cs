/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        public GameStateModel StateModel { get; private set; }
        
        public PlayerPrefsGameStateProvider(IEntityFactoryService entityFactoryService)
        {
            var gameStateData = new GameStateData()
            {
                entities = new List<EntityStateData>()
            };
            
            StateModel = new GameStateModel(gameStateData, entityFactoryService);
        }
        
        public void Dispose()
        {
            
        }

        public IObservable<bool> SaveState()
        {
            return Observable.Return(true);
        }

        public IObservable<bool> ResetState()
        {
            
            return Observable.Return(true);
        }

        public IObservable<GameStateModel> LoadState()
        {
            return Observable.Return(StateModel);
        }

        
    }
}