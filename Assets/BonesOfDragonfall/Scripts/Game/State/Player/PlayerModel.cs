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
        
        public ReactiveProperty<float> MaxSpeed { get; private set; }
        public ReactiveProperty<Vector3> Position { get; private set; }
        public ReactiveProperty<Vector3> ForceMovement { get; private set; }
        public ReactiveProperty<float> DragMovement { get; private set; }
        public ReactiveProperty<Vector3> JumpForce { get; private set; }
        public ReactiveProperty<Quaternion> Rotation { get; private set; }
        public ReactiveProperty<float> HealthPoint { get; private set; }
        public ReactiveProperty<float> CameraRotation { get; private set; }
        
        public PlayerModel(PlayerData originState)
        {
            OriginState = originState;
            
            HealthPoint = new ReactiveProperty<float>(originState.healthPoint);
            Position = new ReactiveProperty<Vector3>(originState.position);

            MaxSpeed = new ReactiveProperty<float>();
            ForceMovement = new ReactiveProperty<Vector3>();
            DragMovement = new ReactiveProperty<float>();
            JumpForce = new ReactiveProperty<Vector3>();
            
            Rotation = new ReactiveProperty<Quaternion>(new Quaternion(0, 0, 0, 1));
            CameraRotation = new ReactiveProperty<float>();
            
            HealthPoint.Subscribe(newHealthPoint => OriginState.healthPoint = newHealthPoint);
            Position.Subscribe(newPosition => OriginState.position = newPosition);
        }
        
    }
}