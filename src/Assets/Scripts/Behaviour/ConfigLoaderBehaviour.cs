using System;
using Assets.Scripts.Types;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class ConfigLoaderBehaviour : MonoBehaviour
    {
        public TextAsset configFile;

        void Start()
        {
            var config = JsonConvert.DeserializeObject<Configuration>(configFile.text);
            ComponentConfig.Instance.RegisterService<Configuration>(config);
        }
    }
}