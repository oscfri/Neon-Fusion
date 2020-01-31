using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BeatCounter : MonoBehaviour
{
    public int BeatsForShort = 1;
    public int BeatsForLong = 2;

    private MusicPlayer musicPlayer;



    // Use this for initialization
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        //BeatCountdown.HasReachedTime.AddListener(Beat);
    }

    public void Beat()
    {
        musicPlayer.Beat();
    }
}
