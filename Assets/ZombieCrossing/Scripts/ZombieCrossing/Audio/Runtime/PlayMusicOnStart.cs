using UnityEngine;

namespace ZombieCrossing.Audio.Runtime
{
    public class PlayMusicOnStart: MonoBehaviour
    {
        [SerializeField] private MusicPlayer musicPlayer;
        [SerializeField] private AudioClip audioClip;

        private void Start()
        {
            musicPlayer.PlayAudioClip(audioClip);
        }
    }
}