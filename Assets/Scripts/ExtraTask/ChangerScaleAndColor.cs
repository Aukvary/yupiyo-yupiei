using UnityEngine;

public class ChangerScaleAndColor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Range(0, 1)] private float value;
    [SerializeField] private Color FirstColor;
    [SerializeField] private Color SecondColor;

    [Header("Referens")]
    [SerializeField] private Transform FirstPosition;
    [SerializeField] private Transform SecondPosition;
    [SerializeField] private Material material;

    private Vector3 basescale;

    private void Awake()
    {
        basescale = transform.localScale;
    }

    private void Update()
    {
        ScaleUpdate();
        PositionUpdate();
        ColorUpdate();
    }

    private void ScaleUpdate()
    {
        float widht = Mathf.Lerp(basescale.x, basescale.x * 10, value);
        float hieght = Mathf.Lerp(basescale.y, basescale.y * 10, 1.01f - value);

        transform.localScale = new Vector3(widht, hieght, widht);
    }

    private void ColorUpdate()
    {
        material.color = Color.Lerp(FirstColor, SecondColor, value);
    }

    private void PositionUpdate()
    {
        transform.position = Vector3.Lerp(FirstPosition.position, SecondPosition.position, value);
    }
}
