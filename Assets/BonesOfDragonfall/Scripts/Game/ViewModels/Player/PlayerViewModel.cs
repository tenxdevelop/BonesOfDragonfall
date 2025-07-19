/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveProperty<Quaternion> CameraRotation { get; }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }

       
    }
}