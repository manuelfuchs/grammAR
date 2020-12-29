using Assets.Scripts.Components;
using Assets.Scripts.Types;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Behaviour
{
    public class LanguageButtonBehaviour : MonoBehaviour, IVirtualButtonEventHandler
    {
        public GameObject languageButton;

        private void Start()
        {
            var virtualButtonBehaviour = this.languageButton.GetComponent<VirtualButtonBehaviour>();
            virtualButtonBehaviour.RegisterEventHandler(this);
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            Debug.LogError("Language button hit");
            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            switch (settingsComponent.Language)
            {
                case Language.English:
                    settingsComponent.Language = Language.German;
                    return;
                case Language.German:
                    settingsComponent.Language = Language.English;
                    return;
            }
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            // Do nothing
        }
    }
}
