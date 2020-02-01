using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour
{
    public string ColorId;

    private VisualBeat visualBeat;
    private Renderer rend;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        visualBeat = GetComponent<VisualBeat>();
        rend = GetComponent<Renderer>();
        originalColor = rend.material.GetColor(ColorId);
    }

    // Update is called once per frame
    void Update()
    {
        Color interpolated = Color.Lerp(originalColor, Color.white, visualBeat.Value);
        rend.material.SetColor(ColorId, interpolated);
    }
}