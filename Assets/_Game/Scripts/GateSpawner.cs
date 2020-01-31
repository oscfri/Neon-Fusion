using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
    public GameObject Gate;
    public float BeatsPerMinute;

    float timeToBeat = 0.0f;

    // Use this for initialization
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timeToBeat -= Time.deltaTime;
        if (timeToBeat <= 0.0f)
        {
            SpawnGate();
            ResetTimer();
        }
    }

    private void SpawnGate()
    {
        Instantiate(Gate, transform);
    }

    private void ResetTimer()
    {
        timeToBeat += 60.0f / BeatsPerMinute;
    }
}
