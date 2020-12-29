using Assets.Scripts.Components.SettingsComponent;
using UnityEngine;

namespace Assets.Scripts.Components.AudioPlayer
{
    public class DefaultAudioPlayer : IAudioPlayer
    {
        public void PlayAudioClip(AudioSource audioSource, AudioClip audioClip, float volume)
        {
            var settings = ComponentConfig.Instance.GetService<ISettingsComponent>();
            if (settings.IsAudioEnabled)
            {
                audioSource.PlayOneShot(audioClip, volume);
            }
        }
    }
}
