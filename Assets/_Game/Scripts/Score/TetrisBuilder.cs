using UnityEngine;
using System.Collections;

public class TetrisBuilder : MonoBehaviour
{
    public Animator anim;
    private float count = 0f;
    bool shouldPlay = false;
    // Use this for initialization
    void Start()
    {
        PlayStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldPlay)
        {
            count += Time.deltaTime;
            if (count >= 120f)
            {
                PlayStop();
            }
        }
    }

    private void PlayStart()
    {
        shouldPlay = true;
        anim.speed = 0.0097f;
        anim.Play("build");
    }

    private void PlayStop()
    {
        Debug.Log("Time is up!");
        shouldPlay = false;
        count = 0;
    }
}