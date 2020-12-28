using UnityEngine;

public class TextCoordinateTransformer : MonoBehaviour
{
    private readonly int _chars_per_line = 70;
    private readonly float _letterHeight = 0.017f;
    private readonly float _letterWidth = 0.012f;
    private const float _xStartingPoint = -2.837f;
    private const float _zStartingPoint = 3.887f;
    public GameObject prefab;
    public GameObject parent;
    public int count = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");

        var go = Instantiate(prefab,
            parent.transform.TransformPoint(new Vector3(_xStartingPoint, 0.8f, _zStartingPoint)),
            Quaternion.identity,
            parent.transform);

        CalcPosition(2, go.transform);

        go.name = "letter box";
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(
        //     $"TEST {parent.transform.localPosition.x} {parent.transform.localPosition.y} {parent.transform.localPosition.z}");
    }

    private void CalcPosition(int count, Transform t)
    {
        var line = 2;
        Debug.Log(
            $"TEST {t.localPosition.x} {t.localPosition.y} {t.localPosition.z}");
        var width = _letterWidth * count;
        var x = _xStartingPoint + _letterWidth * 10 * (count - 1);
        var inv = parent.transform.InverseTransformPoint(t.position);
        t.position = parent.transform.TransformPoint(x, inv.y, inv.z - _letterHeight * 10 * (line - 1));
        t.localScale = new Vector3(width, t.localScale.y, t.localScale.z);
    }
}