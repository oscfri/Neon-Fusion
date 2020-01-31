using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Beat
{
    beat4th,
    beat2th,
    beatwhole,
}

public class MusicSong : MonoBehaviour
{
    public AudioClip song;

    public List<float> ListBeats;

    void Start()
    {

    }

    public void Beat()
    {
        //Debug.Log("MusicSong beat");
    }
}
