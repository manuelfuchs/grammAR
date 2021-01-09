using Assets.Scripts.Types;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class SpellingMistakeLoader : MonoBehaviour
    {
        public TextAsset spellingMistakeFile;

        void Start()
        {
            var config = JsonConvert.DeserializeObject<SpellingMistakes>(spellingMistakeFile.text);
            ComponentConfig.Instance.RegisterService(config);
        }

        void Update()
        {
        }
    }
}