using ZombieCrossing.Pooling.Runtime;
using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    /// <summary>
    /// Creates a pool of <see cref="ParticleBase"/>
    /// </summary>
    public class ParticlePool: GameObjectPoolBase<ParticleFactory, ParticleArgs, ParticleBase>
    {
        [field: SerializeField]
        protected override ParticleFactory Factory { get; set; }

        // public override ParticleBase Allocate(ParticleArgs args)
        // {
        //     return base.Allocate(args);
        // }
        
        // public override void Free(ParticleBase member)
        // {
        //     base.Free(member);
        // }

        // protected override ParticleBase CreateInstance(ParticleArgs args)
        // {
        //     return base.CreateInstance(args);
        // }
    }
}