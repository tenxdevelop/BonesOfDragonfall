/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.Events;
using UnityEngine;

namespace BonesOfDragonfall
{
    [RequireComponent(typeof(Rigidbody))]
    public class ForceToRigidbodyUpdateBinder : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _maxSpeed;

        [SerializeField] private UnityEvent<Vector3> UpdatePositionEvent;
        public void AddForce(Vector3 force)
        {
            _rigidbody.AddForce(force);
            
            var flatVelocity = new Vector3(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);

            if (flatVelocity.magnitude > _maxSpeed)
            {
                var limitedVelocity = flatVelocity.normalized * _maxSpeed;
                _rigidbody.linearVelocity = new Vector3(limitedVelocity.x, _rigidbody.linearVelocity.y, limitedVelocity.z);
            }
        }

        private void LateUpdate()
        {
            UpdatePositionEvent?.Invoke(_rigidbody.position);
        }
    }
}
