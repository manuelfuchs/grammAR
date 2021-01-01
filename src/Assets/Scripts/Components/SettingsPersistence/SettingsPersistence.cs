using Assets.Scripts.Types;
using UnityEngine;

namespace Assets.Scripts.Components.SettingsPersistence
{
    public class SettingsPersistence : ISettingsPersistence
    {
        private const string LangKey = "Language";
        private const string CurseWordEnabledKey = "CurseWordsEnabled";
        private const string AudioEnabledKey = "AudioEnabled";

        public Language Language
        {
            get
            {
                var lang = PlayerPrefs.GetInt(LangKey, -1);
                if (lang == -1)
                {
                    return ComponentConfig.Instance.GetService<Configuration>().Language;
                }

                return (Language) lang;
            }
            set
            {
                PlayerPrefs.SetInt(LangKey, (int) value);
                PlayerPrefs.Save();
            }
        }

        public bool CurseWordFilterEnabled
        {
            get
            {
                var curseWordsEnabled = PlayerPrefs.GetInt(CurseWordEnabledKey, -1);
                if (curseWordsEnabled == -1)
                {
                    return ComponentConfig.Instance.GetService<Configuration>().CurseWordFilterEnabled;
                }

                return curseWordsEnabled == 1;
            }
            set
            {
                PlayerPrefs.SetInt(CurseWordEnabledKey, value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool AudioEnabled
        {
            get
            {
                var audioEnabled = PlayerPrefs.GetInt(AudioEnabledKey, -1);
                if (audioEnabled == -1)
                {
                    return ComponentConfig.Instance.GetService<Configuration>().AudioEnabled;
                }

                return audioEnabled == 1;
            }
            set
            {
                PlayerPrefs.SetInt(AudioEnabledKey, value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }
    }
}