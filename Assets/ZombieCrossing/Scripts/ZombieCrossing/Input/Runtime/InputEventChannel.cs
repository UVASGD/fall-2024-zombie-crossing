using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZombieCrossing.Input.Runtime
{
    /// <summary>
    /// Channel for input events.
    /// </summary>
    [CreateAssetMenu(fileName = nameof(InputEventChannel), menuName = "Scriptable Object/Input/Channels/Input Event Channel")]
    public class InputEventChannel: ScriptableObject
    {
        /// <summary> Callback on move. </summary>
        public event Action<Vector2> OnMove;
        
        /// <summary> Callback on look. </summary>
        public event Action<Vector2> OnLook;

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

        /// <summary> Callback on input activated. </summary>
        public event Action OnActivateInput;

        /// <summary> Callback on input deactivated. </summary>
        public event Action OnDeactivateInput;

        /// <summary> Callback on device lost. </summary>
        public event Action<PlayerInput> OnDeviceLost; 
        
        /// <summary> Callback on device regained. </summary>
        public event Action<PlayerInput> OnDeviceRegained; 
        
        /// <summary> Callback on controls changed. </summary>
        public event Action<PlayerInput> OnControlsChanged; 

        /// <summary> Raises the <see cref="OnMove"/> event. </summary>
        /// <param name="value">The movement value.</param>
        public void RaiseOnMove(Vector2 value) => OnMove?.Invoke(value);
        
        /// <summary> Raises the <see cref="OnLook"/> event. </summary>
        /// <param name="value">The look value.</param>
        public void RaiseOnLook(Vector2 value) => OnLook?.Invoke(value);
        
        /// <summary> Raises the <see cref="OnAttack"/> event. </summary>
        public void RaiseOnAttack() => OnAttack?.Invoke();
        
        /// <summary> Raises the <see cref="OnInteract"/> event. </summary>
        public void RaiseOnInteract() => OnInteract?.Invoke();
        
        /// <summary> Raises the <see cref="OnCrouch"/> event. </summary>
        public void RaiseOnCrouch() => OnCrouch?.Invoke();
        
        /// <summary> Raises the <see cref="OnJump"/> event. </summary>
        public void RaiseOnJump() => OnJump?.Invoke();
        
        /// <summary> Raises the <see cref="OnPrevious"/> event. </summary>
        public void RaiseOnPrevious() => OnPrevious?.Invoke();
        
        /// <summary> Raises the <see cref="OnNext"/> event. </summary>
        public void RaiseOnNext() => OnNext?.Invoke();
        
        /// <summary> Raises the <see cref="OnSprint"/> event. </summary>
        public void RaiseOnSprint() => OnSprint?.Invoke();
        
        /// <summary> Raises the <see cref="OnNavigate"/> event. </summary>
        /// <param name="value">The navigation value.</param>
        public void RaiseOnNavigate(Vector2 value) => OnNavigate?.Invoke(value);
        
        /// <summary> Raises the <see cref="OnSubmit"/> event. </summary>
        public void RaiseOnSubmit() => OnSubmit?.Invoke();
        
        /// <summary> Raises the <see cref="OnCancel"/> event. </summary>
        public void RaiseOnCancel() => OnCancel?.Invoke();

        /// <summary> Raises the <see cref="OnActivateInput"/> event. </summary>
        public void RaiseOnActivateInput() => OnActivateInput?.Invoke();

        /// <summary> Raises the <see cref="OnDeactivateInput"/> event. </summary>
        public void RaiseOnDeactivateInput() => OnDeactivateInput?.Invoke(); 
        
        /// <summary> Raises the <see cref="OnDeviceLost"/> event. </summary>
        /// <param name="playerInput">The lost <see cref="PlayerInput"/>.</param>
        public void RaiseOnDeviceLost(PlayerInput playerInput) => OnDeviceLost?.Invoke(playerInput); 
        
        /// <summary> Raises the <see cref="OnDeviceRegained"/> event. </summary>
        /// <param name="playerInput">The regained <see cref="PlayerInput"/>.</param>
        public void RaiseOnDeviceRegained(PlayerInput playerInput) => OnDeviceRegained?.Invoke(playerInput); 
        
        /// <summary> Raises the <see cref="OnControlsChanged"/> event. </summary>
        /// <param name="playerInput">The reference to a new <see cref="PlayerInput"/> with the changed controls.</param>
        public void RaiseOnControlsChanged(PlayerInput playerInput) => OnControlsChanged?.Invoke(playerInput); 
    }
}