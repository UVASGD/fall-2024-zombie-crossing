using UnityEngine;
using ZombieCrossing.ParticleSystem.Runtime;

namespace ZombieCrossing.Guns.Runtime
{
    /// <summary>
    /// A single bullet particle. 
    /// </summary>
    public class ParticleBullet: ParticleBase
    {
        public override void OnAllocate(ParticleArgs args)
        {
            transform.position = args.origin;
            direction = args.direction;
            initialLinearVelocity = args.initialLinearVelocity;
        }

        public void Update()
        {
            transform.Translate(direction * (initialLinearVelocity * Time.deltaTime));
            // TODO - deal damage if comes in contact with an enemy. 
        }

        public override void OnFree()
        {
            
        }
    }
}