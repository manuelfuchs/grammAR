using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TextCoordinateTransformer : MonoBehaviour
{
    private readonly int _chars_per_line = 70;
    private readonly float _letterHeight = 0.017f;
    private readonly float _letterWidth = 0.012f;
    private const float _xStartingPoint = -2.837f;
    private const float _zStartingPoint = 3.887f;
    public GameObject prefab;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");

        var go = Instantiate(prefab,
            parent.transform.TransformPoint(new Vector3(_xStartingPoint, 0.8f, _zStartingPoint)),
            Quaternion.identity,
            parent.transform);

        go.name = "letter box";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(
            $"TEST {parent.transform.localPosition.x} {parent.transform.localPosition.y} {parent.transform.localPosition.z}");
    }
}