/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public interface IPlayerModel : IEntityStateModel<PlayerData>
    {
        ReactiveProperty<float> HealthPoint { get; }
        ReactiveProperty<Quaternion> Rotation { get; }
        ReactiveProperty<float> CameraRotation { get; }
        ReactiveProperty<Vector3> ForceMovement { get; }
    }
}