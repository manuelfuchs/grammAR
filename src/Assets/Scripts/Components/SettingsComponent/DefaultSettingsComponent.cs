using Assets.Scripts.Types;
using System;

namespace Assets.Scripts.Components.SettingsComponent
{
    public class DefaultSettingsComponent : ISettingsComponent
    {
        private Language language;

        public event Action<Language> OnLanguageChanged;

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
