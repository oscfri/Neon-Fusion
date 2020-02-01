using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMotion : MonoBehaviour
{
    public float Speed;
    private const float RemoveAtZ = -10f;
    private bool hasScored = false;

    private ScoreCounter scoreCounter;
    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponentInChildren<Light>();
    }

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
            Destroy(gameObject);
        }
        else if (transform.position.z <= 0.0)
        {
            if (scoreCounter != null && !hasScored)
            {
                hasScored = true;
                scoreCounter.FailedScore();
            }
            var lightBeat = lightComponent.GetComponent<LightBeat>();
            lightBeat.Active = false;
            //lightComponent.intensity -= 1.0f * Time.deltaTime;
            // lightComponent.range -= 1.0f * Time.deltaTime;
        }
    }
}   