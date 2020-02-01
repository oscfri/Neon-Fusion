using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class BeatCounter : MonoBehaviour
{
    public int BeatsForShort = 1;
    public int BeatsForLong = 2;

    private int beat;
    BeatEvent beater;

    void Awake()
    {
        beater = new BeatEvent();
    }

    public void Attach(UnityAction<bool> action)
    {
        beater.AddListener(action);
    }

    public void Release(UnityAction<bool> action)
    {
        beater.RemoveListener(action);
    }

    public void Beat()
    {
        if (beat % BeatsForLong == 0)
        {
            beater.Invoke(true);
        }
        else if (beat % BeatsForShort == 0)
        {
            beater.Invoke(false);
        }
        beat += 1;
    }
}
