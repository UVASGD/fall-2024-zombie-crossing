using UnityEngine;

namespace ZombieCrossing.TransformUtility.Runtime
{
    public class TransformLookAtTarget: MonoBehaviour
    {
        [SerializeField] private Transform origin;
        [SerializeField] private Transform target;

        private void Update()
        {
            var direction = origin.position - target.position;
            var forwards = Vector3.Cross(direction, origin.up);
            if (forwards.magnitude == 0) return;
            transform.rotation = Quaternion.Euler(0,-90,0) * Quaternion.LookRotation(forwards.normalized);
        }
    }
}