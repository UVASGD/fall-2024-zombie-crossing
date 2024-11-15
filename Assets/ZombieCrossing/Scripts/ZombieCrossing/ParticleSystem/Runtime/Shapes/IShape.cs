using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime.Shapes
{
    public interface IShape
    {
        /// <returns>
        /// The closest normal along the shape's surface that corresponds to a given <paramref name="direction"/>.
        /// </returns>
        public Vector3 ConvertToShapeDirection(Vector3 direction);
    }
}