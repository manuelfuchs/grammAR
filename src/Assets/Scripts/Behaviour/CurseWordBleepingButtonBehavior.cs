﻿using Assets.Scripts.Components;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Behaviour
{
    public class CurseWordBleepingButtonBehavior : MonoBehaviour, IVirtualButtonEventHandler
    {
        public GameObject curseWordBleepingButton;
        public AudioClip buttonPressedAudio;

        private void Start()
        {
            var virtualButtonBehaviour = this.curseWordBleepingButton.GetComponent<VirtualButtonBehaviour>();
            virtualButtonBehaviour.RegisterEventHandler(this);
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            Debug.Log("CWB button hit");
            var audioSource = this.GetComponent<AudioSource>();
            audioSource.PlayOneShot(buttonPressedAudio, 0.7f);

            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            settingsComponent.IsCurseWordBleepingEnabled = !settingsComponent.IsCurseWordBleepingEnabled;
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            // Do nothing
        }
    }
}
