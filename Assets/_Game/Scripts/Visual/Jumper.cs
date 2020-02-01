using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    private VisualBeat visualBeat;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        visualBeat = GetComponent<VisualBeat>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originalPosition + transform.up * visualBeat.Value;
    }
}
