using EventFunctionUtility.Runtime;
using UnityEngine;

namespace ZombieCrossing.TransformUtility.Runtime
{
    public class TransformFollowTarget
    {
        [SerializeField] private Transform target; 
        [SerializeField] private UpdateMethod updateMethod;
    }
}