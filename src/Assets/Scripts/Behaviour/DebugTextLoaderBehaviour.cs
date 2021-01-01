using Assets.Scripts.Types;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class DebugTextLoaderBehaviour : MonoBehaviour
    {
        public TextAsset debugTextFile;

        public void Start()
        {
            var debugTexts = JsonConvert.DeserializeObject<DebugTexts>(debugTextFile.text);
            ComponentConfig.Instance.RegisterService<DebugTexts>(debugTexts);
        }
    }
}