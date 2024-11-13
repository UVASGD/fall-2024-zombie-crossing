using UnityEngine;
using UnityEngine.InputSystem;
using ZombieCrossing.Input.Runtime;
using ZombieCrossing.ParticleSystem.Runtime;

namespace ZombieCrossing.ParticleSystemControl.Runtime
{
    /// <summary>
    /// Plays a particle system once on a specific input. 
    /// </summary>
    public class FireParticleSystem : MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private ParticlePoolSystem particlePoolSystem;
        [SerializeField] private bool isAutomaticFire; 

        private void OnEnable()
        {
            inputHandler.OnAttack += PlayParticleSystemOnce; 
        }

        private void OnDisable()
        {
            inputHandler.OnAttack -= PlayParticleSystemOnce; 
        }

        private void PlayParticleSystemOnce(InputAction.CallbackContext callbackContext)
        {
            if (isAutomaticFire)
            {
                switch (callbackContext.phase)
                {
                    case InputActionPhase.Performed:
                        particlePoolSystem.Play(true);
                        return;
                    case InputActionPhase.Canceled when particlePoolSystem.IsPlaying:
                        particlePoolSystem.Stop();
                        return;
                    case InputActionPhase.Started:
                    case InputActionPhase.Disabled:
                    case InputActionPhase.Waiting:
                    default:
                        return;
                }
            }
            
            if (!callbackContext.started) return; 
            particlePoolSystem.Play(false);
        }
    }
}