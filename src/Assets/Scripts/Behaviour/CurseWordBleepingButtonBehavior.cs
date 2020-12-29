using Assets.Scripts.Components;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Behaviour
{
    public class CurseWordBleepingButtonBehavior : MonoBehaviour, IVirtualButtonEventHandler
    {
        public GameObject curseWordBleepingButton;

        private void Start()
        {
            var virtualButtonBehaviour = this.curseWordBleepingButton.GetComponent<VirtualButtonBehaviour>();
            virtualButtonBehaviour.RegisterEventHandler(this);
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            Debug.LogError("CWB button hit");
            var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            settingsComponent.IsCurseWordBleepingEnabled = !settingsComponent.IsCurseWordBleepingEnabled;
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            // Do nothing
        }
    }
}
