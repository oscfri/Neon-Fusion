﻿using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
    public float Score = 0;
    public float ScoreP1 = 0;
    public float ScoreP2 = 0;

    private float scorePerHit = 10f;
    private float scorePerMultiplier = 10f;
    private float scoreCompletedTower = 40f;

    private float multiplier = 1f;
    private float multiplierAdd = 0.1f;

    private ScoreText[] ScoreText;
    private ScoreSound scoreSound;

    public CameraShake cameraShakeP1;
    public CameraShake cameraShakeP2;

    private void Start()
    {
        ScoreText = FindObjectsOfType<ScoreText>();
        scoreSound = FindObjectOfType<ScoreSound>();
    }

    public void AddScore(Direction direction, int playerNr)
    {
        var amount = GetScore(direction);
        Score += amount;

        if (playerNr == 1)
        {
            ScoreP1 += amount;
            cameraShakeP1.Shake(multiplier);
        }
        else
        {
            ScoreP2 += amount;
            cameraShakeP1.Shake(multiplier);
        }
        scoreSound.PlaySound(direction);
        SetScoreText();
    }

    public void AddScoreCompletedTower()
    {
        Score += scoreCompletedTower;
    }

    public void FailedScore()
    {
        multiplier = 1.0f;
        scoreSound.PlaySound(Direction.none);

        SetScoreText();
    }

    private void SetScoreText()
    {
        foreach (var scoreText in ScoreText)
        {
            scoreText.SetScore(Score + "%");
        }
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
