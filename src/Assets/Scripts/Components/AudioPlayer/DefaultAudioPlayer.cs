using UnityEngine;

namespace Assets.Scripts.Components
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
