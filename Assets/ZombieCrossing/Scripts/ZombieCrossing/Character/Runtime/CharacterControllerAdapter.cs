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

        private float ogHeight;
        private float ogRadius;
        private float normalSpeed = 1f;
        private float crouchSpeed = 0.3f;
        private bool crouchAbility = false;

        private void Start()
        {
            ogHeight = characterController.height;
            ogRadius = characterController.radius;
        }

        private void Awake()
        {
            oldPosition = transform.position;
        }

        private void Update()
        {
            var position = transform.position;
            LinearVelocity = (position - oldPosition) / Time.deltaTime;
            oldPosition = position;

            // shift to crouch
            if(crouchAbility)
            {
                float characterSize = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? 0.5f : 1f;
                characterController.height = ogHeight * characterSize; // height
                characterController.radius = ogRadius * characterSize; // hitbox size
            }
            
        }

        private void FixedUpdate()
        {
            characterController.Move(accumulatedMotion);
            accumulatedMotion = Vector3.zero;
        }
        
        /// <inheritdoc />
        public override void Move(Vector3 motion)
        {
            float speed = (crouchAbility && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) ? crouchSpeed : normalSpeed;
            accumulatedMotion += motion * speed;
        }

        public void setCrouchAbility(bool set)
        {
            crouchAbility = set;
        }
    }
}