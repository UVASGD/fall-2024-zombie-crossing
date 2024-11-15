using System;
using UnityEngine;

public class HungerEventChannel : MonoBehaviour
{
    /// <summary> Callback for player running out of stamina when near zombies (dying) </summary>
    public event Action OnOutOfStaminaNearZombies;

    /// <summary> Callback for player running out of stamina at the end of the week </summary>
    public event Action OnOutOfStaminaAtEndOfWeek;

    /// <summary> Callback for player running out of stamina in a safe area </summary>
    public event Action OnOutOfStaminaInSafeArea;

    public void HandlOutOfStaminaNearZombies() => OnOutOfStaminaNearZombies?.Invoke();
    public void HandleOutOfStaminaAtEndOfWeek() => OnOutOfStaminaAtEndOfWeek?.Invoke();
    public void HandleOutOfStaminaInSafeArea() => OnOutOfStaminaInSafeArea?.Invoke();
}
