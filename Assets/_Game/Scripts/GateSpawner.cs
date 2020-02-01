using UnityEngine;
using System.Collections;

public class GateSpawner : MonoBehaviour
{
    public GameObject Gate;

    public Transform LastGateTransform { get; private set; }


    public void SpawnGate()
    {
        GameObject spawned = Instantiate(Gate, transform);
        LastGateTransform = spawned.transform;
    }
}
