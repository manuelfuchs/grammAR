using Assets.Scripts.Components.SpellChecker;
using UnityEngine;

namespace Assets.Scripts
{
    public class SheetHider : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
            Debug.LogWarning($"Loaded {spellChecker.GetType().FullName}");
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}