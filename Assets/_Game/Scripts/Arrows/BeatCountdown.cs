using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatCountdown : MonoBehaviour
{
    // Start is called before the first frame update
    private float current = 0;
    public float BeatTime = 0.25f;

    private bool hasStarted = false;

    public UnityEvent HasReachedTime;

    void Start()
    {
        current = BeatTime;
    }

    public void BeatStart()
    {
        hasStarted = true;
    }

    public void BeatStop()
    {
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) return;

        current -= Time.deltaTime;
        if (current <= 0)
        {
            ReachedTime();
        }
    }

    private void ReachedTime()
    {
        current += BeatTime;
        HasReachedTime.Invoke();
    }
}
