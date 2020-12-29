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
            Debug.Log("Audio button hit");
            var audioSource = this.GetComponent<AudioSource>();
            audioSource.PlayOneShot(buttonPressedAudio, 0.7f);

            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            settingsComponent.IsAudioEnabled = !settingsComponent.IsAudioEnabled;
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            // Do nothing
        }
    }
}
