using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime.DirectionGeneration
{
    /// <summary>
    /// Generates a random direction within a specified cone.
    /// </summary>
    [System.Serializable]
    public class RandomDirectionInCone : IDirectionGenerator
    {
        /// <summary>
        /// The vertex angle of the cone. 
        /// </summary>
        [SerializeField, Range(0, 180)] private float vertexAngle = 30f; 

        /// <summary>
        /// Generates a random normalized direction within the cone.
        /// </summary>
        /// <returns>A normalized vector within the cone's angle.</returns>
        public Vector3 GetDirection()
        {
            var coneAngleRadians = Mathf.Deg2Rad * vertexAngle;
            var z = Random.Range(Mathf.Cos(coneAngleRadians), 1f);
            var theta = Random.Range(0f, Mathf.PI * 2);
            
            var sineConeAngleRadians = Mathf.Sqrt(1 - z * z);
            var x = sineConeAngleRadians * Mathf.Cos(theta);
            var y = sineConeAngleRadians * Mathf.Sin(theta);
            var direction = new Vector3(x, y, z);
            
            return direction;
        }
    }
}