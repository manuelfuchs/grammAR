using Assets.Scripts.Components;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Behaviour
{
    public class AudioButtonBehaviour : MonoBehaviour, IVirtualButtonEventHandler
    {
        public GameObject audioButton;
        public AudioClip buttonPressedAudio;

        private void Start()
        {
            var virtualButtonBehaviour = this.audioButton.GetComponent<VirtualButtonBehaviour>();
            virtualButtonBehaviour.RegisterEventHandler(this);
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            Debug.Log("Audio button pressed");

            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            settingsComponent.IsAudioEnabled = !settingsComponent.IsAudioEnabled;

            var audioPlayer = ComponentConfig.Instance.GetService<IAudioPlayer>();
            var audioSource = this.GetComponent<AudioSource>();
            audioPlayer.PlayAudioClip(audioSource, this.buttonPressedAudio, 0.7f);
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            // Do nothing
        }
    }
}
