using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    public class ParticleEmpty: ParticleBase
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
        }

        public override void OnFree()
        {
            
        }
    }
}