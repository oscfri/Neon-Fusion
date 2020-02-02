using UnityEngine;
using System.Collections;

public class TetrisBuilder : MonoBehaviour
{
    public Animator anim;
    private float count = 0f;
    bool shouldPlay = false;

    private int block;

    // Use this for initialization
    void Start()
    {
        var scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.Attach(OnScore);
        PlayStart();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnScore(bool successfulScore)
    {
        if (successfulScore)
        {
            block += 1;
        }
        anim.SetInteger("Block", block);
    }

    private void PlayStart()
    {
        shouldPlay = true;
        //anim.speed = 1.0f / 60.0f;
        anim.Play("Start");
    }

    private void PlayStop()
    {
        Debug.Log("Time is up!");
        shouldPlay = false;
        count = 0;
    }
}