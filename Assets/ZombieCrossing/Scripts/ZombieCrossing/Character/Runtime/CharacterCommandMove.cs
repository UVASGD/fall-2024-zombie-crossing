using UnityEngine;
using ZombieCrossing.CommandPattern.Runtime;

namespace ZombieCrossing.Character.Runtime
{
    /// <summary>
    /// Command used to move a rigidbody  
    /// </summary>
    public readonly struct CharacterCommandMove: ICommand
    {
        private readonly BaseCharacterController characterController;
        private readonly Vector3 motion;
        private readonly Quaternion axis; 
        private readonly float friction;

        /// <param name="characterController">The Character controller.</param>
        /// <param name="motion">The amount to add to the movement.</param>
        /// <param name="axis">The angle by which to rotate the movement.</param>
        /// <param name="friction">A normalized value representing the total percent of movement that will be lost.</param>
        public CharacterCommandMove(BaseCharacterController characterController, Vector3 motion, Quaternion axis, float friction)
            : this()
        {
            this.characterController = characterController;
            this.motion = motion;
            this.axis = axis;
            this.friction = friction;
        }
        
        /// <inheritdoc />
        public void Execute()   
        {
            characterController.Move((characterController.LinearVelocity + axis * motion) * (1 - friction));
        }
    }
}