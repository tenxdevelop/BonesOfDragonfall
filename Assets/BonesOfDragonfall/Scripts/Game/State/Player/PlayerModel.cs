/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.Reactive;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerModel : IPlayerModel
    {
        public PlayerData OriginState { get; private set; }
        public EntityType EntityType =>  OriginState.entityType;
        public int UniqueId =>  OriginState.uniqueId;
        public string ConfigId => OriginState.configId;
        public ReactiveProperty<float> HealthPoint { get; private set; }
        public ReactiveCollection<MagicElementData> MagicCast { get; private set; }
        public ReactiveProperty<float> MaxSpeed { get; private set; }
        public ReactiveProperty<Vector3> Position { get; private set; }
        public ReactiveProperty<Vector3> ForceMovement { get; private set; }
        public ReactiveProperty<float> DragMovement { get; private set; }
        public ReactiveProperty<Vector3> JumpForce { get; private set; }
        public ReactiveProperty<Quaternion> Rotation { get; private set; }
        public ReactiveProperty<Vector3> ScaleCollider { get; private set; }
        public ReactiveProperty<float> CameraRotation { get; private set; }
        
        public PlayerModel(PlayerData originState)
        {
            OriginState = originState;
            
            HealthPoint = new ReactiveProperty<float>(originState.healthPoint);
            UpdateMagicCast(originState.magicCast);
            
            Position = new ReactiveProperty<Vector3>(originState.position);

            MaxSpeed = new ReactiveProperty<float>();
            ForceMovement = new ReactiveProperty<Vector3>();
            DragMovement = new ReactiveProperty<float>();
            JumpForce = new ReactiveProperty<Vector3>();
            
            Rotation = new ReactiveProperty<Quaternion>(new Quaternion(0, 0, 0, 1));
            CameraRotation = new ReactiveProperty<float>();

            ScaleCollider = new ReactiveProperty<Vector3>(new Vector3(1, 1, 1));
            
            HealthPoint.Subscribe(newHealthPoint => OriginState.healthPoint = newHealthPoint);
            Position.Subscribe(newPosition => OriginState.position = newPosition);
        }

        private void UpdateMagicCast(List<MagicElementData> magicCast)
        {
            MagicCast = new ReactiveCollection<MagicElementData>();
            foreach (var magicElement in magicCast)
            {
                MagicCast.Add(magicElement);
            }

            MagicCast.Subscribe(OnMagicElementAdded, OnMagicElementRemoved, OnMagicCastClear);
        }

        private void OnMagicCastClear()
        {
            OriginState.magicCast.Clear();
        }

        private void OnMagicElementRemoved(MagicElementData removedMagicElement)
        {
            var removedMagicElementData = OriginState.magicCast.FirstOrDefault(magicElement => magicElement.Equals(removedMagicElement));
            OriginState.magicCast.Remove(removedMagicElement);
        }

        private void OnMagicElementAdded(MagicElementData newMagicElement)
        {
            OriginState.magicCast.Add(newMagicElement);
        }
    }
}