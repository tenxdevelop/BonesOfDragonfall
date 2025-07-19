using UnityEngine;

namespace BonesOfDragonfall
{
    public class FloatToTransformRotationAxisRightBinder : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public void Perform(float angle)
        {
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
        }
    }
}