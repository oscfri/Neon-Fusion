using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
    public GameObject Gate;

    public Transform LastGateTransform;

    public void SpawnGate()
    {
        GameObject spawned = Instantiate(Gate, transform);
        LastGateTransform = spawned.transform;
    }
}
