using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
    public float Score = 0;
    public float ScoreP1 = 0;
    public float ScoreP2 = 0;

    private float scorePerHit = 1f;
    private float scorePerMultiplier = 10f;
    private float scoreCompletedTower = 40f;

    private float multiplier = 1f;
    private float multiplierAdd = 0.1f;

    public void AddScore(Direction direction, int playerNr)
    {
        var amount = GetScore(direction);
        Score += amount;

        if (playerNr == 1)
        {
            ScoreP1 += amount;
            Debug.Log("P1 Score: " + ScoreP1);
        }
        else
        {
            ScoreP2 += amount;
            Debug.Log("P2 Score: " + ScoreP2);
        }
        Debug.Log("Score: " + Score);
    }

    public void AddScoreCompletedTower()
    {
        Score += scoreCompletedTower;
    }

    public void FailedScore()
    {
        multiplier = 1.0f;
    }

    private void IncreaseMultiplier()
    {
        multiplier += multiplierAdd;
    }

    public void Reset()
    {
        multiplier = 1f;
        Score = 0;
    }

    private float GetScore(Direction direction)
    {
        if (direction == Direction.special)
        {
            IncreaseMultiplier();
            return scorePerMultiplier * multiplier;
        }
        return scorePerHit * multiplier;
    }
}
