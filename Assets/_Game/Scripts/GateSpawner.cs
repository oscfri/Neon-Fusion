using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
    public GateMotion Gate;
    private ScoreCounter scoreCounter;

    public Transform LastGateTransform { get; private set; }

    private BeatCounter beatCounter;
    private bool isAllowedToSpawn = true;
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

    public void StopSpawning()
    {
        isAllowedToSpawn = false;
    }

    void InvokeBeat(bool isLong)
    {
        if (!isAllowedToSpawn) return;
        GateMotion spawned = Instantiate(Gate, transform);
        spawned.Speed = gateSpeed;
        LastGateTransform = spawned.transform;
    }
}
