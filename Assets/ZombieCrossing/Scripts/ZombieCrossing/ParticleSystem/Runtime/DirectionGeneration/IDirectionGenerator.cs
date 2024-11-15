using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime.DirectionGeneration
{
    /// <summary>
    /// Generates a direction. 
    /// </summary>
    public interface IDirectionGenerator
    {
        public Vector3 GetDirection(); 
    }
}