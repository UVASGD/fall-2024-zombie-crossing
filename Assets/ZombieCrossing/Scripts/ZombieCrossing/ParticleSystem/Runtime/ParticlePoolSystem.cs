using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using ZombieCrossing.ParticleSystem.Runtime.DirectionGeneration;
using ZombieCrossing.ParticleSystem.Runtime.Shapes;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    /// <summary>
    /// Creates a particle system of items from a <see cref="ParticlePool"/>
    /// </summary>
    public class ParticlePoolSystem: MonoBehaviour 
    {
        [Header("Particle System")]
        [SerializeField]
        private ParticlePool pool;
        
        /// <summary>
        /// How long each particle lives in seconds.
        /// </summary>
        [SerializeField, Min(0)] 
        private float lifetime;

        /// <summary>
        /// The initial linear velocity of each particle.
        /// </summary>
        [SerializeField, Min(0)] 
        private float initialLinearVelocity;

        /// <summary>
        /// Whether to play the particle system on <see cref="Start"/>.
        /// </summary>
        [SerializeField] 
        private bool playOnStart;
        
        /// <summary>
        /// The rate at which to spawn particles in seconds. 
        /// </summary>
        [Header("Emission")]
        [SerializeField, Min(0)] 
        private float rateOverTime;

        /// <summary>
        /// The number of particles to emit at once. 
        /// </summary>
        [SerializeField, Min(1)] 
        private int burstCount = 1;

        /// <summary>
        /// The <see cref="IShape"/> through which this should emit particles.
        /// </summary>
        [UsedImplicitly, SerializeReference, SubclassSelector]
        private IDirectionGenerator directionGenerator;

        private CancellationTokenSource resetCancellation = new();

        private void Awake()
        {
            pool.Prewarm();
            burstCount = Mathf.Min(burstCount, pool.MaxPoolSize);
        }

        private void Start()
        {
            if (!playOnStart) return;
            Play();
        }

        public void Stop()
        {
            resetCancellation.Dispose();
            resetCancellation.Cancel();
        }

        public void Play()
        {
            resetCancellation = new CancellationTokenSource();
            UpdateSystem(resetCancellation.Token);
        }

        private async void UpdateSystem(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var particles = new ParticleBase[burstCount];
                
                for (var i = 0; i < burstCount; i++)
                {
                    if (cancellationToken.IsCancellationRequested || pool == null) return;
                    var particleArgs = new ParticleArgs(pool.Parent.position, 
                        transform.rotation * directionGenerator?.GetDirection() ?? Vector3.zero, 
                        initialLinearVelocity);
                    
                    particles[i] = pool.Allocate(particleArgs);

                    if (!ReferenceEquals(particles[i], null)) continue;

                    while (pool.IsCompletelyInUse) await Awaitable.NextFrameAsync(cancellationToken);
                }

                foreach (var particle in particles)
                {
                    if (particle == null) continue;
                    particle.gameObject.SetActive(true);
                    FreeParticleAfterSeconds(particle, cancellationToken);
                }

                await Awaitable.WaitForSecondsAsync(rateOverTime, cancellationToken);
            }
        }

        private async void FreeParticleAfterSeconds(ParticleBase particle, CancellationToken cancellationToken)
        {
            await Awaitable.WaitForSecondsAsync(lifetime, cancellationToken);
            particle.gameObject.SetActive(false);
            pool.Free(particle);
        }
    }
}