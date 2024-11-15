using ZombieCrossing.Pooling.Runtime;
using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    /// <summary>
    /// Creates a <see cref="ParticleBase"/>
    /// </summary>
    public class ParticleFactory: MonoBehaviour, IFactory<ParticleBase>
    {
        [SerializeField] 
        private GameObject particle; 
        
        public ParticleBase CreateInstance()
        {
            var instance = Instantiate(particle);
            if (instance.TryGetComponent(out ParticleBase component)) return component;
            component = instance.AddComponent<ParticleEmpty>();
            return component;
        }
    }
}