using UnityEngine;
using ZombieCrossing.Character.Runtime;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.Player.Runtime
{
    /// <summary>
    /// Handles the player sprinting.
    /// </summary>
    public class PlayerSprint : MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private BaseCharacterController characterController;
        [SerializeField] private float normalSpeed = 5f; // Default walk speed
        [SerializeField] private float sprintSpeedMultiplier = 2f; // Sprint speed is 2x normal speed
        private bool isSprinting = false; // Tracks whether sprinting is active

        private void OnEnable()
        {
            // Subscribe to the OnSprint event
            inputHandler.OnSprint += HandleSprintInput;
        }

        private void OnDisable()
        {
            // Unsubscribe to prevent memory leaks
            inputHandler.OnSprint -= HandleSprintInput;
        }

        /// <summary>
        /// Toggles the sprint state when the sprint key is pressed.
        /// </summary>
        private void HandleSprintInput()
        {
            // Toggle sprinting on and off with each press
            isSprinting = !isSprinting;
        }

        /// <summary>
        /// Applies the sprint multiplier to the player's velocity.
        /// Call this in the PlayerMovementHandler class to modify movement speed.
        /// </summary>
        /// <param name="linearVelocity">The player's current movement velocity.</param>
        public void ApplySprint(ref Vector3 linearVelocity)
        {
            // If sprinting, multiply the player's movement speed by the sprint multiplier
            float currentSpeed = isSprinting ? normalSpeed * sprintSpeedMultiplier : normalSpeed;
            linearVelocity = Vector3.ClampMagnitude(linearVelocity, currentSpeed);

            // Apply the updated velocity to the character controller
            characterController.Move(linearVelocity);
        }
    }
}
