using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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