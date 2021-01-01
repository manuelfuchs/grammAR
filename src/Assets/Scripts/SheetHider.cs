using Assets.Scripts.Components.SpellChecker;
using UnityEngine;

namespace Assets.Scripts
{
    public class SheetHider : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}