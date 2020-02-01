using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMotion : MonoBehaviour
{
    public float Speed;
    private const float RemoveAtZ = -1.6f;
    private bool hasScored = false;

    private ScoreCounter scoreCounter;

    public void SetScoreCounter(ScoreCounter scoreCounter)
    {
        this.scoreCounter = scoreCounter;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Speed * Time.deltaTime;

        if (transform.position.z <= RemoveAtZ)
        {
            if (scoreCounter != null && !hasScored)
            {
                hasScored = true;
                scoreCounter.FailedScore();
            }
            Destroy(gameObject);
        }
    }
}   