using Assets.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Behaviour
{
    public class SettingsTextBehaviour : MonoBehaviour
    {
        private const string NewLine = "\n";
        private const string LanguageTextFormat =
            "Language: {0}" + NewLine
            + "Audio: {1}" + NewLine
            + "Curse Word Bleeping: {2}";

        public void Start()
        {
            this.UpdateSettingsText();

            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            settingsComponent.OnSettingsChanged += UpdateSettingsText;
        }

        private void UpdateSettingsText()
        {
            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            var settingsText = GetComponent<Text>();

            string audioValueText;
            if (settingsComponent.IsAudioEnabled)
            {
                audioValueText = "Enabled";
            }
            else
            {
                audioValueText = "Disabled";
            }

            string curseWordBleepingText;
            if (settingsComponent.IsCurseWordBleepingEnabled)
            {
                curseWordBleepingText = "Enabled";
            }
            else
            {
                curseWordBleepingText = "Disabled";
            }

            settingsText.text = string.Format(
                LanguageTextFormat,
                settingsComponent.Language,
                audioValueText,
                curseWordBleepingText);
        }
    }
}