using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Components.AudioPlayer;
using Assets.Scripts.Components.SpellChecker;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class AudioFeedbackBehaviour : MonoBehaviour
    {
        private ISpellChecker spellChecker;
        private IAudioPlayer audioPlayer;
        public AudioClip onSucessClip;
        public AudioClip onErrorClip;


        // Start is called before the first frame update
        void Start()
        {
            spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
            audioPlayer = ComponentConfig.Instance.GetService<IAudioPlayer>();

            spellChecker.OnMistakesFound += mistakes =>
            {
                var audioSource = this.GetComponent<AudioSource>();

                if (mistakes.Any())
                {
                    audioPlayer.PlayAudioClip(audioSource, onErrorClip, 0.7f);
                }
                else
                {
                    audioPlayer.PlayAudioClip(audioSource, onSucessClip, 0.7f);
                }
            };
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}