using Assets.Scripts.Types;
using System;

namespace Assets.Scripts.Components
{
    public class DefaultSettingsComponent : ISettingsComponent
    {
        private Language language = Language.German;
        private bool isAudioEnabled = true;
        private bool isCurseWordBleepingEnabled = false;

        public event Action OnSettingsChanged;

        public Language Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;

                if (this.OnSettingsChanged != null)
                {
                    this.OnSettingsChanged.Invoke();
                }
            }
        }

        public bool IsAudioEnabled
        {
            get
            {
                return this.isAudioEnabled;
            }
            set
            {
                this.isAudioEnabled = value;

                if (this.OnSettingsChanged != null)
                {
                    this.OnSettingsChanged.Invoke();
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

                if (this.OnSettingsChanged != null)
                {
                    this.OnSettingsChanged.Invoke();
                }
            }
        }
    }
}
