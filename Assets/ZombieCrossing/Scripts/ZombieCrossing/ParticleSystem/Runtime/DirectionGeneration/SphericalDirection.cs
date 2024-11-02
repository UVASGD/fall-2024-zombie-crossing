using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime.DirectionGeneration
{
    /// <summary>
    /// Returns a normal in an arbitrary normal polygon.
    /// </summary>
    [System.Serializable]
    public class SphericalDirection: IDirectionGenerator
    {
        /// <summary>
        /// The amount of faces on the polygon.
        /// </summary>
        [field: SerializeField]
        public int Faces { get; set; }

        private int faceIndex; 
        
        public Vector3 GetDirection()
        {
            faceIndex %= Faces;
            var direction = FibonacciSphere(Faces, faceIndex);
            faceIndex++;
            return direction;
        }

        /// <summary>
        /// The golden angle in radians (i.e. pi * (sqrt(5) - 1))
        /// </summary>
        private const float GoldenAngle = 2.39996322972865332f;

        /// <summary>
        /// Gets nth point on Fibonacci sphere. 
        /// </summary>
        /// <param name="samples">The number of evenly spaced points on the sphere.</param>
        /// <param name="index">The nth point.</param>
        /// modified from: https://stackoverflow.com/a/26127012/25169483
        private static Vector3 FibonacciSphere(int samples, int index)
        {
            var y = 1f - index / (samples - 1f) * 2f;
            var radius = Mathf.Sqrt(1f - y * y);
            var theta = GoldenAngle * index;
            var x = Mathf.Cos(theta) * radius;
            var z = Mathf.Sin(theta) * radius;
            return new Vector3(x, y, z);
        }
    }
}