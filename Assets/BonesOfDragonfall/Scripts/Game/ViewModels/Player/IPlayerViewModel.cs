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
        ReactiveProperty<Vector3> ForceMovement { get; }
        ReactiveProperty<Quaternion> Rotation { get; }
        ReactiveProperty<float> CameraRotation { get; }
        
        void UpdatePosition(object sender, Vector3 position);
    }
}