using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    /// <summary>
    /// Arguments used to create a single <see cref="ParticleBase"/>.
    /// </summary>
    [System.Serializable]
    public readonly struct ParticleArgs
    {
        public readonly Vector3 origin;
        public readonly Vector3 direction;
        public readonly float initialLinearVelocity;

        /// <param name="origin">The position this particle should start at.</param>
        /// <param name="direction">The direction this particle should move.</param>
        /// <param name="initialLinearVelocity">The initial linear velocity of this particle.</param>
        public ParticleArgs(Vector3 origin, Vector3 direction, float initialLinearVelocity)
        {
            this.direction = direction;
            this.origin = origin;
            this.initialLinearVelocity = initialLinearVelocity;
        }
    }
}