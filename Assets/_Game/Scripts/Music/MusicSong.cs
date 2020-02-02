using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MusicSong : MonoBehaviour
{
    public AudioClip song;
    int currentBeat = 0;
    private int currentIndex = 0;

    public int CurrentIndex { get { return currentIndex; } }

    public List<int> ListBeats; //Beats required to spawn
    public List<Direction> ListDirections; //Beats

    //public List<Tuple<int, Direction>> ListBeats;

    void Start()
    {
        
    }

    public void Reset()
    {
        currentIndex = 0;
        currentBeat = 0;
    }

    public Direction GetAndCheckBeat()
    {
        var direction = Direction.none;
        if (currentBeat >= ListBeats[currentIndex])
        {
            currentBeat = 0;
            direction = ListDirections[currentIndex];
            currentIndex++;
        }
        currentBeat++;
        return direction;
    }
}
