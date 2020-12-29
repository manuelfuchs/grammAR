using System;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SettingsComponent
{
    public interface ISettingsComponent
    {
        event Action<Language> OnLanguageChanged;

        Language Language { get; set; }
    }
}
