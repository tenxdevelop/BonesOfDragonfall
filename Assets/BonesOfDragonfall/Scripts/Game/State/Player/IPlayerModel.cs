/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public interface IPlayerModel : IEntityStateModel<PlayerData>, IMagicEntity
    {
        ReactiveProperty<float> HealthPoint { get; }
        ReactiveProperty<float> MaxHealthPoint { get; }
        ReactiveProperty<float> MaxSpeed { get; }
        ReactiveProperty<Vector3> ScaleCollider { get; }
        ReactiveProperty<Quaternion> Rotation { get; }
        ReactiveProperty<float> CameraRotation { get; }
        ReactiveProperty<Vector3> ForceMovement { get; }
        ReactiveProperty<Vector3> JumpForce { get; }
        ReactiveProperty<float> DragMovement { get; }
    }
}