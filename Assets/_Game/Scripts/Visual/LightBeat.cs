using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeat : MonoBehaviour
{
    public float TargetRange = 40.0f;

    private VisualBeat visualBeat;
    private Light lightComponent;
    private Color originalColor;
    private float originalRange;

    // Start is called before the first frame update
    void Start()
    {
        visualBeat = GetComponent<VisualBeat>();
        lightComponent = GetComponentInChildren<Light>();
        originalColor = lightComponent.color;
        originalRange = lightComponent.range;
    }

    // Update is called once per frame
    void Update()
    {
        Color interpolatedColor = Color.Lerp(originalColor, Color.white, visualBeat.Value);
        float interpolatedRange = Mathf.Lerp(originalRange, TargetRange, visualBeat.Value);
        lightComponent.color = interpolatedColor;
        lightComponent.range = interpolatedRange;
    }
}
