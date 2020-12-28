using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Behaviour
{
    public class LanguageButtonBehaviour : MonoBehaviour, IVirtualButtonEventHandler
    {
        private void Start()
        {
            var languageButton = GameObject.Find("LanguageSettingButton");
            languageButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            Debug.LogError("Language Button pressed.");
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            Debug.LogError("Language Button released.");
        }
    }
}
