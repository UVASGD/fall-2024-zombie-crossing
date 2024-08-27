using UnityEngine;

namespace ZombieCrossing.Character.Runtime
{
    /// <summary>
    /// Base class for all character controllers. 
    /// </summary>
    public abstract class BaseCharacterController: MonoBehaviour
    {
        /// <summary>
        /// Moves the character controller.
        /// </summary>
        /// <param name="motion"></param>
        public abstract void Move(Vector3 motion); 
        
        /// <summary>
        /// The linear velocity of the character controller, representing its rate of change.
        /// </summary>
        public abstract Vector3 LinearVelocity { get; protected set; }
    }
}