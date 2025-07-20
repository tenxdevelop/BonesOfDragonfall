/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    public class JumpForceToRigidbodyBinder : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Perform(Vector3 jumpForce)
        {
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, 0f, _rigidbody.linearVelocity.z);
            
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }
    
}
