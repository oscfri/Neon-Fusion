using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BeatCounter : MonoBehaviour
{
    public int BeatsForShort = 1;
    public int BeatsForLong = 2;

    private MusicPlayer musicPlayer;
    private GateSpawner gateSpawner;

    // Use this for initialization
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        gateSpawner = FindObjectOfType<GateSpawner>();
        //BeatCountdown.HasReachedTime.AddListener(Beat);
    }

    public void Beat()
    {
        musicPlayer.Beat();
        gateSpawner.SpawnGate();
    }
}
