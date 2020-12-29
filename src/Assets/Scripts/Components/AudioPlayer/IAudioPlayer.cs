using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public interface IAudioPlayer
    {
        void PlayAudioClip(AudioSource audioSource, AudioClip audioClip, float volume);
    }
}
