using JetBrains.Annotations;
using UnityEngine;
using ZombieCrossing.ParticleSystem.Runtime.Shapes;

namespace ZombieCrossing.ParticleSystem.Runtime.DirectionGeneration
{
    /// <summary>
    /// Returns a random surface normal in a shape. 
    /// </summary>
    [System.Serializable]
    public class RandomDirectionInShape: IDirectionGenerator
    {
        [UsedImplicitly, SerializeReference, SubclassSelector]
        private IShape shape;

        public Vector3 GetDirection()
        {
            return shape?.ConvertToShapeDirection(Random.insideUnitSphere) ?? Vector3.zero;
        }
    }
}