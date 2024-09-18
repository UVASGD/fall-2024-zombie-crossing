using UnityEngine;
using ZombieCrossing.CommandPattern.Runtime;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.Player.Runtime
{
    public class InteractionHandler: MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask includeLayers; 
        private readonly Collider[] colliders = new Collider[16];
        private int collidersCount;

        public void OnEnable()
        {
            inputHandler.OnInteract += TryInteract;
        }
        
        public void OnDisable()
        {
            inputHandler.OnInteract -= TryInteract;
        }

        private void FixedUpdate()
        {
            collidersCount = Physics.OverlapSphereNonAlloc(transform.position, radius, colliders, includeLayers);
        }

        /// <summary>
        /// Executes any <see cref="ICommand"/> in a <see cref="radius"/>.
        /// </summary>
        private void TryInteract()
        {
            for (var i = 0; i < collidersCount; i++)
            {
                if (!colliders[i].TryGetComponent<ICommand>(out var interactionCommand)) continue; 
                interactionCommand.Execute();
            }
        }  
    }
}