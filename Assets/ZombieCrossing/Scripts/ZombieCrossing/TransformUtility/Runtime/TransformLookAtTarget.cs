using UnityEngine;

namespace ZombieCrossing.TransformUtility.Runtime
{
    public class TransformLookAtTarget : MonoBehaviour
    {
        [SerializeField] private Transform origin;
        [SerializeField] private Transform target;
        [SerializeField] private Axis ignoredAxes = Axis.None;

        private void Update()
        {
            var direction = origin.position - target.position;

            direction = new Vector3(
                ignoredAxes.HasFlag(Axis.X) ? 0 : direction.x,
                ignoredAxes.HasFlag(Axis.Y) ? 0 : direction.y,
                ignoredAxes.HasFlag(Axis.Z) ? 0 : direction.z
            );
            
            var forwards = Vector3.Cross(direction, origin.up);
            if (forwards == Vector3.zero) return;
            
            transform.rotation = Quaternion.Euler(0,-90,0) * Quaternion.LookRotation(forwards.normalized);
        }
    }
}