using System;
using Assets.Scripts.Components.SettingsPersistence;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SettingsComponent
{
    public class DefaultSettingsComponent : ISettingsComponent
    {
        private Language language;
        private bool isAudioEnabled;
        private bool isCurseWordBleepingEnabled;
        private readonly ISettingsPersistence settingsPersistence;

        public DefaultSettingsComponent()
        {
            settingsPersistence = ComponentConfig.Instance.GetService<ISettingsPersistence>();
            language = settingsPersistence.Language;
            isAudioEnabled = settingsPersistence.AudioEnabled;
            isCurseWordBleepingEnabled = settingsPersistence.CurseWordFilterEnabled;
        }

        public event Action<bool> OnIsAudioEnabledChanged;
        public event Action<bool> OnIsCWBEnabledChanged;
        public event Action<Language> OnLanguageChanged;

        public bool IsAudioEnabled
        {
            get { return this.isAudioEnabled; }
            set
            {
                if (this.isAudioEnabled != value)
                {
                    settingsPersistence.AudioEnabled = value;
                }

                this.isAudioEnabled = value;

                if (this.OnIsAudioEnabledChanged != null)
                {
                    this.OnIsAudioEnabledChanged.Invoke(this.isAudioEnabled);
                }
            }
        }

        public bool IsCurseWordBleepingEnabled
        {
            get { return this.isCurseWordBleepingEnabled; }
            set
            {
                if (this.isCurseWordBleepingEnabled != value)
                {
                    settingsPersistence.CurseWordFilterEnabled = value;
                }

                this.isCurseWordBleepingEnabled = value;

                if (this.OnIsCWBEnabledChanged != null)
                {
                    this.OnIsCWBEnabledChanged.Invoke(this.isCurseWordBleepingEnabled);
                }
            }
        }

        public Language Language
        {
            get { return this.language; }
            set
            {
                if (this.language != value)
                {
                    settingsPersistence.Language = value;
                }

                this.language = value;

                if (this.OnLanguageChanged != null)
                {
                    this.OnLanguageChanged.Invoke(this.language);
                }
            }
        }
    }
}