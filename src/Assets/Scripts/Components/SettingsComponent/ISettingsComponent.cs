using System;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components
{
    public interface ISettingsComponent
    {
        event Action OnSettingsChanged;

        Language Language { get; set; }
        bool IsAudioEnabled { get; set; }
        bool IsCurseWordBleepingEnabled { get; set; }
    }
}
