using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class VolumeBeat : MonoBehaviour
{
    public float TargetChromatic = 0.5f;
    public float TargetBloom = 60.0f;

    private VisualBeat visualBeat;
    private UnityEngine.Rendering.Universal.ChromaticAberration chromaticComponent;
    private UnityEngine.Rendering.Universal.Bloom bloomComponent;
    private float originalChromatic;
    private float originalBloom;

    // Start is called before the first frame update
    void Start()
    {
        visualBeat = GetComponent<VisualBeat>();
        var volumeComponent = GetComponentInChildren<Volume>();
        var volumeProfile = volumeComponent.profile;
        var volumeComponents = volumeProfile.components;
        foreach (var component in volumeComponents)
        {
            if (component is UnityEngine.Rendering.Universal.ChromaticAberration)
            {
                chromaticComponent = (UnityEngine.Rendering.Universal.ChromaticAberration)component;
                originalChromatic = chromaticComponent.intensity.value;
            }
            else if (component is UnityEngine.Rendering.Universal.Bloom)
            {
                bloomComponent = (UnityEngine.Rendering.Universal.Bloom)component;
                originalBloom = bloomComponent.intensity.value;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float interpolatedChromatic = Mathf.Lerp(originalChromatic, TargetChromatic, visualBeat.Value);
        float interpolatedBloom = Mathf.Lerp(originalBloom, TargetBloom, visualBeat.Value);
        chromaticComponent.intensity.value = interpolatedChromatic;
        bloomComponent.intensity.value = interpolatedBloom;
    }
}
