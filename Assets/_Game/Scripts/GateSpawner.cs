using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
    public GateMotion Gate;
    private ScoreCounter scoreCounter;

    public Transform LastGateTransform { get; private set; }

    private BeatCounter beatCounter;
    private float gateSpeed;

    void Start()
    {
        beatCounter = FindObjectOfType<BeatCounter>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
        beatCounter.Attach(InvokeBeat);
        float beatTime = FindObjectOfType<BeatCountdown>().BeatTime;
        gateSpeed = (transform.position.z - 2) / (8 * beatTime);
    }

    public void SetMaterial(Material mat, Color color)
    {
        MeshRenderer renderer = LastGateTransform.GetComponentInChildren<MeshRenderer>();
        Light light = LastGateTransform.GetComponentInChildren<Light>();
        LastGateTransform.GetComponent<GateMotion>().SetScoreCounter(scoreCounter);
        light.color = color;
        renderer.material = mat;
    }

    void OnDestroy()
    {
        beatCounter.Release(InvokeBeat);
    }

    void InvokeBeat(bool isLong)
    {
        GateMotion spawned = Instantiate(Gate, transform);
        spawned.Speed = gateSpeed;
        LastGateTransform = spawned.transform;
    }
}
