using UnityEngine;
using ZombieCrossing.Character.Runtime;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.Player.Runtime
{
    /// <summary>
    /// Handles the player movement.
    /// </summary>
    public class PlayerMovementHandler: MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private BaseCharacterController characterController;
        [SerializeField] private float acceleration;
        [SerializeField, Min(0)] private float maxSpeed; 
        [SerializeField, Min(0)] private float drag;
        [SerializeField] private float gravity; 
        [SerializeField] private Transform referenceAxis;
        private Vector3 inputDirection; 
        private Vector3 linearVelocity;
        
        private void OnEnable()
        {
            inputHandler.OnMove += HandleOnMove;
        }
        
        private void OnDisable()
        {
            inputHandler.OnMove -= HandleOnMove;
        }

        private void HandleOnMove(Vector2 value)
        {
            inputDirection = new Vector3(value.x, 0, value.y);
        }

        private void FixedUpdate()
        {
            var rotation = Quaternion.Euler(0, referenceAxis.eulerAngles.y, 0);
            linearVelocity += inputDirection * (acceleration * Time.deltaTime);
            linearVelocity += Vector3.up * (gravity * Time.deltaTime);
            linearVelocity *= 1 - drag * Time.deltaTime;
            linearVelocity = Vector3.ClampMagnitude(linearVelocity, maxSpeed);
            characterController.Move(rotation * linearVelocity);
        }
    }
}