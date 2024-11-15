using System;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using ZombieCrossing.ParticleSystem.Runtime.DirectionGeneration;
using ZombieCrossing.ParticleSystem.Runtime.Shapes;
using ZombieCrossing.ThreadingExtensions.Runtime;

namespace ZombieCrossing.ParticleSystem.Runtime
{
    /// <summary>
    /// Creates a particle system of items from a <see cref="ParticlePool"/>
    /// </summary>
    public class ParticlePoolSystem: MonoBehaviour 
    {
        [Header("Particle System")]
        [SerializeField] private ParticlePool pool;

        /// <summary>
        /// The <see cref="Transform"/> at which each particle will spawn
        /// within its <see cref="ParticlePool.Parent"/>.
        /// </summary>
        [SerializeField] private Transform origin;
        
        /// <summary>
        /// How long each particle lives in seconds.
        /// </summary>
        [SerializeField, Min(0)] private float lifetime;

        /// <summary>
        /// The initial linear velocity of each particle.
        /// </summary>
        [SerializeField, Min(0)] private float initialLinearVelocity;

        /// <summary>
        /// Whether to play the particle system on <see cref="Start"/>.
        /// </summary>
        [SerializeField] private bool playOnStart;
        
        /// <summary>
        /// Whether the particle system is currently playing. 
        /// </summary>
        public bool IsPlaying { get; private set; }
        
        /// <summary>
        /// The rate at which to spawn particles in seconds. 
        /// </summary>
        [Header("Emission")]
        [SerializeField, Min(0)] private float rateOverTime;

        /// <summary>
        /// The number of particles to emit at once. 
        /// </summary>
        [SerializeField, Min(1)] private int burstCount = 1;

        /// <summary>
        /// The <see cref="IShape"/> through which this should emit particles.
        /// </summary>
        [UsedImplicitly, SerializeReference, SubclassSelector] private IDirectionGenerator directionGenerator;

        private CancellationTokenSource resetCancellation = new();

        private void Awake()
        {
            pool.Prewarm();
            burstCount = Mathf.Min(burstCount, pool.MaxPoolSize);
        }

        private void Start()
        {
            if (!playOnStart) return;
            Play(true);
        }

        public void Stop()
        {
            IsPlaying = false;
            resetCancellation.CancelAndDispose();
        }

        public void Play(bool repeat)
        {
            resetCancellation = new CancellationTokenSource();
            IsPlaying = true;
            UpdateSystem(repeat, resetCancellation.Token);
        }

        private async void UpdateSystem(bool repeat, CancellationToken cancellationToken)
        {
            try
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var particles = new ParticleBase[burstCount];

                    for (var i = 0; i < burstCount; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        if (pool == null) return;
                        
                        var direction = transform.rotation * directionGenerator?.GetDirection() ?? Vector3.zero;
                        var particleArgs = new ParticleArgs(origin.position, direction, initialLinearVelocity);

                        particles[i] = pool.Allocate(particleArgs);
                        if (!ReferenceEquals(particles[i], null)) continue;

                        while (pool.IsCompletelyInUse) await Awaitable.NextFrameAsync(cancellationToken);
                    }

                    foreach (var particle in particles)
                    {
                        if (particle == null) continue;
                        particle.gameObject.SetActive(true);
                        FreeParticleAfterSeconds(particle);
                    }

                    if (!repeat)
                    {
                        Stop();
                        return;
                    }
                    
                    await Awaitable.WaitForSecondsAsync(rateOverTime, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async void FreeParticleAfterSeconds(ParticleBase particle)
        {
            await Awaitable.WaitForSecondsAsync(lifetime);
            particle.gameObject.SetActive(false);
            pool.Free(particle);
        }
    }
}