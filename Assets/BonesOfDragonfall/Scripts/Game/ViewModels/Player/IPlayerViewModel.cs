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
        ReactiveProperty<Vector3> Position { get; }
        ReactiveProperty<Quaternion> CameraRotation { get; }
    }
}