/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class DoorViewModel : IDoorViewModel
    {
        public void Dispose()
        {
            
        }

        [ReactiveMethod]
        public void Interact(object sender)
        {
            Debug.Log("Open door yaaa");
        }
        
        public void PhysicsUpdate(float deltaTime)
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}
