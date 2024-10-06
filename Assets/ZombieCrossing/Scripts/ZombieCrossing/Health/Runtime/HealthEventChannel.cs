using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace ZombieCrossing.Health.Runtime
{
    /// <summary>
    /// Handles and invokes health events (perhaps split this into player health and enemy health in the future).
    /// </summary>
    public class HealthEventChannel : MonoBehaviour
    {
        /// <summary> Callback for player hit </summary>
        public event Action OnPlayerHit;

        /// <summary> Callback for player death </summary>
        public event Action OnPlayerDeath;


        public void HandlePlayerHit() => OnPlayerHit?.Invoke();
        public void HandlePlayerDeath() => OnPlayerDeath?.Invoke();
    }
}
