using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeat : MonoBehaviour
{
    public float TargetIntensity = 40.0f;
    public float TargetRange = 40.0f;

    private VisualBeat visualBeat;
    private Light lightComponent;
    private float originalIntensity;
    private float originalRange;

    // Start is called before the first frame update
    void Start()
    {
        visualBeat = GetComponent<VisualBeat>();
        lightComponent = GetComponentInChildren<Light>();
        originalIntensity = lightComponent.intensity;
        originalRange = lightComponent.range;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolatedIntensity = Mathf.Lerp(originalIntensity, TargetIntensity, visualBeat.Value);
        float interpolatedRange = Mathf.Lerp(originalRange, TargetRange, visualBeat.Value);
        lightComponent.intensity = interpolatedIntensity;
        lightComponent.range = interpolatedRange;
    }
}
