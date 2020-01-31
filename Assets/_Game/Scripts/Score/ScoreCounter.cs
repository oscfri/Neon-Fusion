using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
    public float Score = 0;

    private float scorePerHit = 1f;
    private float scorePerMultiplier = 10f;

    private float multiplier = 1f;
    private float multiplierAdd = 0.1f;


    public void AddScore(Direction direction)
    {
        Score += GetScore(direction);
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
            return multiplierAdd * multiplier;
        }
        return scorePerHit * multiplier;
    }
}
