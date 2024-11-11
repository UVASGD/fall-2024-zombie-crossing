using EventFunctionUtility.Runtime;
using UnityEngine;

namespace ZombieCrossing.TransformUtility.Runtime
{
    public class TransformFollowTarget: MonoBehaviour
    {
        [SerializeField] private Transform target; 
        [SerializeField] private UpdateMethod updateMethod;

        private void Update()
        {
            if (updateMethod != UpdateMethod.Update) return; 
            FollowTarget();
        }

        private void FixedUpdate()
        {
            if (updateMethod != UpdateMethod.FixedUpdate) return;
            FollowTarget();
        }

        private void LateUpdate()
        {
            if (updateMethod != UpdateMethod.LateUpdate) return;
            FollowTarget();
        }
        
        private void FollowTarget()
        {
            transform.position = target.position;
        }
    }
}