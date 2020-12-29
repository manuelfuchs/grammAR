using UnityEngine;

namespace Assets.Scripts.Components.AudioPlayer
{
    public interface IAudioPlayer
    {
        void PlayAudioClip(AudioSource audioSource, AudioClip audioClip, float volume);
    }
}
