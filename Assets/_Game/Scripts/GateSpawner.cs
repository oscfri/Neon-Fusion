using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
    public GameObject Gate;
    private ScoreCounter scoreCounter;

    public Transform LastGateTransform { get; private set; }

    private BeatCounter beatCounter;
    private bool isAllowedToSpawn = true;

    void Start()
    {
        beatCounter = FindObjectOfType<BeatCounter>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
        beatCounter.Attach(InvokeBeat);
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

    public void SpawnGate()
    {
        // GameObject spawned = Instantiate(Gate, transform);
        // LastGateTransform = spawned.transform;
    }

    public void StopSpawning()
    {
        isAllowedToSpawn = false;
        Debug.Log("Stop spawning gates!");
    }

    void InvokeBeat(bool isLong)
    {
        if (!isAllowedToSpawn) return;

        GameObject spawned = Instantiate(Gate, transform);
        LastGateTransform = spawned.transform;
    }
}
