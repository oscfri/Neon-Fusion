using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour
{
    // Use this for initialization
    private ScoreTextMoverUp[] scoreMovers;
    void Start()
    {
        scoreMovers = FindObjectsOfType<ScoreTextMoverUp>();
    }

    private void StopSpawning()
    {
        ArrowGenerator[] arrowGenerators = FindObjectsOfType<ArrowGenerator>();
        foreach (ArrowGenerator generator in arrowGenerators)
        {
            generator.StopSpawning();
        }

        GateSpawner[] gateSpawners = FindObjectsOfType<GateSpawner>();
        foreach (GateSpawner gate in gateSpawners)
        {
            gate.StopSpawning();
        }
    }

    public void Win()
    {
        StopSpawning();

        foreach(ScoreTextMoverUp mover in scoreMovers)
        {
            mover.PlayMovement();
        }
        Debug.Log("Yay you are a winrar!");
    }
}
