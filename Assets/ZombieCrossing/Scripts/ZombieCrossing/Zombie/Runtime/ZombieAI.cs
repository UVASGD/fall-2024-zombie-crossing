using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using ZombieCrossing.Health.Runtime;

namespace ZombieCrossing.Zombie.Runtime
{
    public class ZombieAI : MonoBehaviour
    {
        private enum EnemyState { Wandering, Chasing, DealingDamage }
        private EnemyState currentState = EnemyState.Wandering;

        public GameObject player;
        public float chaseRadius = 10f;
        public float wanderSpeed = 2f;
        public float chaseSpeed = 4f;
        public int damage = 5;

        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private HealthEventChannel healthEventChannel;

        private Vector3 wanderTarget;
        private float wanderRadius = 5f;

        void Start()
        {
            SetRandomWanderTarget();
            currentState = EnemyState.Wandering;
            StartCoroutine(ChangeWanderTargetPeriodically());
        }

        void Update()
        {
            Debug.Log(currentState);
            switch (currentState)
            {
                case EnemyState.Wandering:
                    Wander();
                    CheckForPlayerInRange();
                    break;

                case EnemyState.Chasing:
                    ChasePlayer();
                    CheckForPlayerInRange();
                    break;

                case EnemyState.DealingDamage:
                    DealDamage();
                    break;
            }
        }

        private void Wander()
        {
            transform.position = Vector3.MoveTowards(transform.position, wanderTarget, wanderSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, wanderTarget) < 0.5f)
            {
                StartCoroutine(AgentWait());
                SetRandomWanderTarget();
            }
        }

        private void SetRandomWanderTarget()
        {
            Vector3 randomDirection = new Vector3(
                UnityEngine.Random.Range(-wanderRadius, wanderRadius),
                0f,
                UnityEngine.Random.Range(-wanderRadius, wanderRadius)
            );

            Vector3 potentialTarget = transform.position + randomDirection;
            NavMeshHit hit;

            // Check if the target is on the NavMesh within a certain distance
            if (NavMesh.SamplePosition(potentialTarget, out hit, 1.0f, NavMesh.AllAreas))
            {
                // Check if a valid path can be calculated to the target
                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(hit.position, path);

                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    wanderTarget = hit.position; // Set the valid position as the target
                    agent.SetDestination(wanderTarget);
                }
                else
                {
                    // Retry setting a new wander target if the path is not complete
                    SetRandomWanderTarget();
                }
            }
            else
            {
                // Retry if the sampled position is not valid
                SetRandomWanderTarget();
            }
        }

        private void CheckForPlayerInRange()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log(distanceToPlayer);
            // overlapsphere because charactercontrollers suck lol
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.Equals(player))
                {
                    currentState = EnemyState.DealingDamage;
                    StartCoroutine(AgentWait());
                    break;
                }
            }
            if (currentState != EnemyState.DealingDamage)
            {
                if (distanceToPlayer <= chaseRadius)
                {
                    currentState = EnemyState.Chasing;
                    chaseRadius = 20; // It'll take more distance to de-aggro the zombie
                }
                else
                {
                    agent.ResetPath();
                    currentState = EnemyState.Wandering;
                    chaseRadius = 10;
                }
            }
            
        }

        private void ChasePlayer()
        {
            agent.SetDestination(player.transform.position);
        }

        // This method will continuously be called as long as the player is touching the Zombie, but the player has immunity frames and the enemy pauses after touching the player for 0.5s.
        private void DealDamage()
        {
            healthEventChannel.HandlePlayerHit(damage);
            currentState = EnemyState.Chasing;
        }

        private IEnumerator AgentWait()
        {
            agent.ResetPath();
            yield return new WaitForSeconds(0.5f);
        }

        private IEnumerator ChangeWanderTargetPeriodically()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                if (currentState == EnemyState.Wandering)
                {
                    SetRandomWanderTarget();
                }
            }
        }
    }
}
