using Assets.Scripts.Types;
using System;

namespace Assets.Scripts.Components
{
    public interface ISettingsComponent
    {
        event Action<Language> OnLanguageChanged;

        Language Language { get; set; }
    }
}
