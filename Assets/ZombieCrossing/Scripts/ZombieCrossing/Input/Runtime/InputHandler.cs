using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZombieCrossing.Input.Runtime
{
    /// <summary>
    /// Handles and invokes input events.
    /// </summary>
    public class InputHandler: MonoBehaviour
    {
        /// <summary>
        /// The <see cref="UnityEngine.InputSystem.PlayerInput"/>.
        /// </summary>
        [field: SerializeField]
        public PlayerInput PlayerInput { get; private set; }
        
        /// <summary> Callback on move. </summary>
        public event Action<Vector2> OnMove; 
        
        /// <summary> Callback on look. </summary>
        public event Action<Vector2> OnLook;

        /// <summary> Callback on pointer position. </summary>
        public event Action<Vector2> OnPointerPosition;
        
        /// <summary> Callback on attack. </summary>
        public event Action OnAttack;
        
        /// <summary> Callback on interact. </summary>
        public event Action OnInteract;
        
        /// <summary> Callback on crouch. </summary>
        public event Action OnCrouch;
        
        /// <summary> Callback on jump. </summary>
        public event Action OnJump;
        
        /// <summary> Callback on previous. </summary>
        public event Action OnPrevious;
        
        /// <summary> Callback on next. </summary>
        public event Action OnNext;
        
        /// <summary> Callback on sprint. </summary>
        public event Action OnSprint;
        
        /// <summary> Callback on navigate (UI). </summary>
        public event Action<Vector2> OnNavigate;
        
        /// <summary> Callback on submit (UI). </summary>
        public event Action OnSubmit;
        
        /// <summary> Callback on cancel (UI). </summary>
        public event Action OnCancel; 
        
        public void HandleMove(InputAction.CallbackContext context) => HandleVector2Input(context, vector => OnMove?.Invoke(vector));
        public void HandleLook(InputAction.CallbackContext context) => HandleVector2Input(context, vector => OnLook?.Invoke(vector));
        public void HandlePointerPosition(InputAction.CallbackContext context) => HandleVector2Input(context, vector => OnPointerPosition?.Invoke(vector));
        public void HandleNavigate(InputAction.CallbackContext context) => HandleVector2Input(context, vector => OnNavigate?.Invoke(vector));
        public void HandleAttack(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnAttack?.Invoke());
        public void HandleInteract(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnInteract?.Invoke());
        public void HandleCrouch(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnCrouch?.Invoke());
        public void HandleJump(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnJump?.Invoke());
        public void HandlePrevious(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnPrevious?.Invoke());
        public void HandleNext(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnNext?.Invoke());
        public void HandleSprint(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnSprint?.Invoke());
        public void HandleSubmit(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnSubmit?.Invoke());
        public void HandleCancel(InputAction.CallbackContext context) => HandleButtonInput(context, () => OnCancel?.Invoke());

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
    }
}