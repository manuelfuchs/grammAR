using System;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SettingsComponent
{
    public class DefaultSettingsComponent : ISettingsComponent
    {
        private Language language = Language.German;
        private bool isAudioEnabled = true;
        private bool isCurseWordBleepingEnabled = false;

        public event Action<bool> OnIsAudioEnabledChanged;
        public event Action<bool> OnIsCWBEnabledChanged;
        public event Action<Language> OnLanguageChanged;

        public bool IsAudioEnabled
        {
            get
            {
                return this.isAudioEnabled;
            }
            set
            {
                this.isAudioEnabled = value;

                if (this.OnIsAudioEnabledChanged != null)
                {
                    this.OnIsAudioEnabledChanged.Invoke(this.isAudioEnabled);
                }
            }
        }

        public bool IsCurseWordBleepingEnabled
        {
            get
            {
                return this.isCurseWordBleepingEnabled;
            }
            set
            {
                this.isCurseWordBleepingEnabled = value;

                if (this.OnIsCWBEnabledChanged != null)
                {
                    this.OnIsCWBEnabledChanged.Invoke(this.isCurseWordBleepingEnabled);
                }
            }
        }

        public Language Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;

                if (this.OnLanguageChanged != null)
                {
                    this.OnLanguageChanged.Invoke(this.language);
                }
            }
        }
    }
}
