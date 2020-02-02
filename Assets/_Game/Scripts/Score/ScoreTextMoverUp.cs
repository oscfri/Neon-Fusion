using UnityEngine;
using System.Collections;

public class ScoreTextMoverUp : MonoBehaviour
{
    private bool hasStarted = false;
    private Vector3 desiredPosition;

    private float speedMove = 1.2f;
    private float speedRotation = 0.5f;
    private float rotCountdown = 0f;

    // Use this for initialization
    void Start()
    {
        desiredPosition = new Vector3(0, 2, 3.5f);
    }

    public void PlayMovement()
    {
        hasStarted = true;
        Debug.Log("Play movement!");
        //animator.Play("ScoreMoveAndRotate");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            if (transform.position.y < desiredPosition.y)
            {
                var pos = transform.position;
                transform.position = new Vector3(pos.x, pos.y + speedMove * Time.deltaTime, pos.z);
            }

            transform.Rotate(new Vector3(-50 * speedRotation * Time.deltaTime, 0, 0));

            rotCountdown += 1f * Time.deltaTime;

            if (rotCountdown >= 3f)
            {
                HasReachedDestination();
            }
        }
    }

    private void HasReachedDestination()
    {
        hasStarted = false;
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.DisplayHighscore();
    }
}
