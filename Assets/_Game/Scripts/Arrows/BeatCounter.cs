using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BeatCounter : MonoBehaviour
{
    public int BeatsForShort = 1;
    public int BeatsForLong = 2;

    public BeatCountdown BeatCountdown;
    

    // Use this for initialization
    void Start()
    {
        Debug.Log("Beat start");

        //BeatCountdown.HasReachedTime.AddListener(Beat);
        BeatCountdown.BeatStart();
    }

    public void Beat()
    {
        Debug.Log("Beat!");
    }
}
