using ZombieCrossing.Pooling.Runtime;
using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    /// <summary>
    /// A single particle
    /// </summary>
    public abstract class ParticleBase: MonoBehaviour, IPooledItem<ParticleArgs>, IGameObjectProvider
    {
        protected Vector3 direction;
        protected float initialLinearVelocity;

        public abstract void OnAllocate(ParticleArgs args);

        public abstract void OnFree();

        public virtual void OnFreeFailed()
        {
            Destroy(gameObject);
        }
    }
}