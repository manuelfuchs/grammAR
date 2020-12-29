using System;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components
{
    public interface ISettingsComponent
    {
        event Action<bool> OnIsAudioEnabledChanged;
        event Action<bool> OnIsCWBEnabledChanged;
        event Action<Language> OnLanguageChanged;

        bool IsAudioEnabled { get; set; }
        bool IsCurseWordBleepingEnabled { get; set; }
        Language Language { get; set; }
    }
}
