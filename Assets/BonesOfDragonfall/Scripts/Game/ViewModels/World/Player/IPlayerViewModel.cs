/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public interface IPlayerViewModel : IViewModel
    {
        ReactiveProperty<float> MaxSpeed { get; }
        ReactiveProperty<Vector3> ForceMovement { get; }
        ReactiveProperty<float> DragMovement { get; }
        ReactiveProperty<Vector3> JumpForce { get; }
        ReactiveProperty<Quaternion> Rotation { get; }
        ReactiveProperty<Vector3> ScaleCollider { get; }
        ReactiveProperty<float> CameraRotation { get; }
        
        void UpdatePosition(object sender, Vector3 position);

        void PlayerInGround(object sender);
        
        void PlayerNotInGround(object sender);
    }
}