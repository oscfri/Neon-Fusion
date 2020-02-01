using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BeatCounter : MonoBehaviour
{
    public int BeatsForShort = 1;
    public int BeatsForLong = 2;

    private MusicPlayer musicPlayer;
    public GateSpawner gateSpawnerP1;
    public GateSpawner gateSpawnerP2;

    // Use this for initialization
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    public void Beat()
    {
        musicPlayer.Beat();
        gateSpawnerP1.SpawnGate();
        gateSpawnerP2.SpawnGate();
    }
}
