using UnityEngine;
using UnityEngine.AI;

namespace ZombieCrossing.NPC.Runtime
{
    public class NavMeshAgentFollowTarget: MonoBehaviour
    {
        /// <summary>
        /// The agent to follow
        /// </summary>
        [SerializeField] private Transform target;

        /// <summary>
        /// The <see cref="navMeshAgent"/> that controls movement.
        /// </summary>
        [SerializeField] private NavMeshAgent navMeshAgent;
        
        private void Update()
        {
            if (!target) return;
            if (Vector3.Distance(transform.position, target.position) > 10) return;
            if (Vector3.Distance(transform.position, target.position) < navMeshAgent.stoppingDistance) return;
            navMeshAgent.SetDestination(target.position);

            // var path = new NavMeshPath();
            // NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            // var movementDirection = path.status == NavMeshPathStatus.PathComplete
            //     ? (path.corners[1] - transform.position).normalized
            //     : Vector3.zero;
            //
            // navMeshAgent.Move(movementDirection);
        }
    }
}