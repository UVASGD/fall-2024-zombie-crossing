using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZombieCrossing.Input.Runtime
{
    /// <summary>
    /// Broadcasts and receives input events. 
    /// </summary>
    public class InputEventHandler: MonoBehaviour
    {
        /// <summary>
        /// The <see cref="UnityEngine.InputSystem.PlayerInput"/>.
        /// </summary>
        [field: SerializeField]
        public PlayerInput PlayerInput { get; private set; }

        /// <summary>
        /// The <see cref="InputEventChannel"/> to send input events to. 
        /// </summary>
        [SerializeField]
        private InputEventChannel inputEventChannel;

        public void OnEnable()
        {
            PlayerInput.onDeviceLost += HandleDeviceLost;
            PlayerInput.onDeviceRegained += HandleDeviceRegained;
            PlayerInput.onControlsChanged += HandleControlsChanged;
            inputEventChannel.OnDeactivateInput += HandleDeactivateInput;
            inputEventChannel.OnActivateInput += HandleActivateInput;
        } 
        
        public void OnDisable()
        {
            PlayerInput.onDeviceLost -= HandleDeviceLost;
            PlayerInput.onDeviceRegained -= HandleDeviceRegained;
            PlayerInput.onControlsChanged -= HandleControlsChanged;
            inputEventChannel.OnDeactivateInput -= HandleDeactivateInput;
            inputEventChannel.OnActivateInput -= HandleActivateInput;
        }
        
        // Vector2 controls assigned via Unity events.
        public void HandleMove(InputAction.CallbackContext context) => HandleVector2Input(context, inputEventChannel.RaiseOnMove);
        public void HandleLook(InputAction.CallbackContext context) => HandleVector2Input(context, inputEventChannel.RaiseOnLook);
        public void HandleNavigate(InputAction.CallbackContext context) => HandleVector2Input(context, inputEventChannel.RaiseOnNavigate);
        
        // Button controls assigned via Unity events.
        public void HandleAttack(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnAttack);
        public void HandleInteract(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnInteract);
        public void HandleCrouch(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnCrouch);
        public void HandleJump(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnJump);
        public void HandlePrevious(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnPrevious);
        public void HandleNext(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnNext);
        public void HandleSprint(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnSprint);
        public void HandleSubmit(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnSubmit);
        public void HandleCancel(InputAction.CallbackContext context) => HandleButtonInput(context, inputEventChannel.RaiseOnCancel);

        /// <summary>
        /// Handles a Vector2 input.
        /// </summary>
        /// <param name="callbackContext">The callback context.</param>
        /// <param name="handler">Handles the input.</param>
        private static void HandleVector2Input(InputAction.CallbackContext callbackContext, Action<Vector2> handler)
        {
            handler(callbackContext.ReadValue<Vector2>()); 
        }

        /// <summary>
        /// Handles a button input. 
        /// </summary>
        /// <param name="callbackContext">The callback context.</param>
        /// <param name="handler">Handles the input.</param>
        private static void HandleButtonInput(InputAction.CallbackContext callbackContext, Action handler)
        {
            if (!callbackContext.started) return;
            handler();
        }

        private void HandleDeactivateInput()
        {
            PlayerInput.DeactivateInput();
        }

        private void HandleActivateInput()
        {
            PlayerInput.ActivateInput();
        }

        private void HandleDeviceLost(PlayerInput playerInput)
        {
            inputEventChannel.RaiseOnDeviceLost(playerInput);
        }

        private void HandleDeviceRegained(PlayerInput playerInput)
        {
            inputEventChannel.RaiseOnDeviceRegained(playerInput);
        }

        private void HandleControlsChanged(PlayerInput playerInput)
        {
            inputEventChannel.RaiseOnControlsChanged(playerInput);
        }
    }
}