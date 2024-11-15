using System.Threading;
using UnityEngine;
using ZombieCrossing.ThreadingExtensions.Runtime;

namespace ZombieCrossing.Audio.Runtime
{
    /// <summary>
    /// Controls music playback. 
    /// </summary>
    public class MusicPlayer: MonoBehaviour
    {
        [SerializeField, Min(1)] private int crossFadeSteps = 1;
        private readonly AudioSource[] audioSources = new AudioSource[2];
        private int activeAudioSourceIndex;
        private CancellationTokenSource cancellationTokenSource = new();

        private void Awake()
        {
            activeAudioSourceIndex = 0;
            audioSources[0] = gameObject.AddComponent<AudioSource>();
            audioSources[1] = gameObject.AddComponent<AudioSource>();   
        }

        private void OnDisable()
        {
            cancellationTokenSource.CancelAndDispose();    
        }
        
        /// <summary>
        /// Plays an audio clip with cross-fade. 
        /// </summary>
        public async void PlayAudioClip(AudioClip audioClip)
        {
            cancellationTokenSource.CancelAndDispose();
            cancellationTokenSource = new CancellationTokenSource();
            
            var fadingInAudioSourceIndex = (activeAudioSourceIndex + 1) % audioSources.Length;
            audioSources[fadingInAudioSourceIndex].clip = audioClip;
            audioSources[fadingInAudioSourceIndex].Play();
            
            for (var i = 0; i < crossFadeSteps; i++)
            {
                var t = (float)i / crossFadeSteps;
                audioSources[fadingInAudioSourceIndex].volume = Mathf.Lerp(0, 1, t);
                audioSources[fadingInAudioSourceIndex].volume = Mathf.Lerp(1, 0, t);
                await Awaitable.NextFrameAsync(cancellationTokenSource.Token);
            }
            
            audioSources[activeAudioSourceIndex].Stop();
            activeAudioSourceIndex = fadingInAudioSourceIndex;
        }
    }
}