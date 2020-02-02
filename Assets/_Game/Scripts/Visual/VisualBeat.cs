using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBeat : MonoBehaviour
{
    public float ShortValue = 0.5f;
    public float LongValue = 1.0f;
    public float Decay = 0.01f;

    public float LogValue = 0.0f;
    public float Value = 0.0f;

    private BeatCounter beatCounter;

    // Start is called before the first frame update
    void Start()
    {
        LogValue = Mathf.Log(LongValue);
        beatCounter = FindObjectOfType<BeatCounter>();
        beatCounter.Attach(InvokeBeat);
    }

    private void Update()
    {
        SetValue(LogValue + Mathf.Log(Decay) * Time.deltaTime);
    }

    private void InvokeBeat(bool isLong)
    {
        if (isLong)
        {
            SetValue(Mathf.Log(LongValue));
        }
        else
        {
            SetValue(Mathf.Log(Value + ShortValue));
        }
    }

    private void SetValue(float newLogValue)
    {
        LogValue = newLogValue;

        Value = Mathf.Exp(LogValue);

        if (Value < 0.0f)
        {
            Value = 0.0f;
        }
        if (Value > LongValue)
        {
            Value = LongValue;
        }
    }
}
