/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerModel : IPlayerModel
    {
        public PlayerData OriginState { get; private set; }
        public EntityType EntityType =>  OriginState.entityType;
        public int UniqueId =>  OriginState.uniqueId;
        
        public string ConfigId => OriginState.configId;
        
        public ReactiveProperty<Vector3> Position { get; private set; }
        
        public ReactiveProperty<float> HealthPoint { get; private set; }
        
        public PlayerModel(PlayerData originState)
        {
            OriginState = originState;
            
            HealthPoint = new ReactiveProperty<float>(originState.healthPoint);
            Position = new ReactiveProperty<Vector3>(originState.position);
            
            HealthPoint.Subscribe(newHealthPoint => OriginState.healthPoint = newHealthPoint);
            Position.Subscribe(newPosition => OriginState.position = newPosition);
        }
        
    }
}