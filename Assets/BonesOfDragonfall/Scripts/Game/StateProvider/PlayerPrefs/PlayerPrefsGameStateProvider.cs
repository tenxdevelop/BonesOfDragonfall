/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.Reactive;
using UnityEngine;

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
                globalEntityId = 2,
                entities = new List<EntityStateData>()
                {
                    new PlayerData()
                    {
                        entityType = EntityType.Player,
                        configId = "playerConfig",
                        position = new Vector3(0, 1, 0),
                        healthPoint = 100,
                        uniqueId = 1
                    }
                }
            };
            
            StateModel = new GameStateModel(gameStateData, entityFactoryService);
        }
        
        public void Dispose()
        {
            
        }
        
        public IPlayerModel GetPlayerModel()
        {
            foreach (var entity in StateModel.Entities)
            {
                if (entity.EntityType.Equals(EntityType.Player))
                    return entity as IPlayerModel;
            }
            
            return null;
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