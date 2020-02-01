using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMotion : MonoBehaviour
{
    public float Speed;
    private const float RemoveAtZ = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Speed * Time.deltaTime;

        if (transform.position.z <= RemoveAtZ)
        {
            Destroy(gameObject);
        }
    }
}
