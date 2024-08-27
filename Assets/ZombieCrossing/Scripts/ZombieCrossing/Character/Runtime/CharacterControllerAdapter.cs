using UnityEngine;

namespace ZombieCrossing.Character.Runtime
{
    /// <summary>
    /// Adapts the <see cref="CharacterController"/> class to be compatible with <see cref="BaseCharacterController"/>.
    /// </summary>
    public class CharacterControllerAdapter: BaseCharacterController
    {
        [SerializeField] 
        private CharacterController characterController;
        
        public override Vector3 LinearVelocity { get; protected set; }
        
        private Vector3 oldPosition;

        private Vector3 accumulatedMotion;

        private void Awake()
        {
            oldPosition = transform.position;
        }

        private void Update()
        {
            var position = transform.position;
            LinearVelocity = (position - oldPosition) / Time.deltaTime;
            oldPosition = position;
        }

        private void FixedUpdate()
        {
            characterController.Move(accumulatedMotion);
            accumulatedMotion = Vector3.zero;
        }
        
        /// <inheritdoc />
        public override void Move(Vector3 motion)
        {
            accumulatedMotion += motion;
        }
    }
}