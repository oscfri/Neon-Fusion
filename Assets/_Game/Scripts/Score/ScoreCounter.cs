using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public float Score = 0;
    public float ScoreP1 = 0;
    public float ScoreP2 = 0;

    private float scorePerHit = 10f;
    private float scorePerMultiplier = 10f;

    private float multiplier = 1f;
    private float multiplierAdd = 0.1f;

    private ScoreText[] ScoreText;
    private ScoreSound scoreSound;

    public CameraShake cameraShakeP1;
    public CameraShake cameraShakeP2;

    ScoreEvent scoreEvent;

    private void Start()
    {
        ScoreText = FindObjectsOfType<ScoreText>();
        scoreSound = FindObjectOfType<ScoreSound>();
        scoreEvent = new ScoreEvent();
    }

    public void Attach(UnityAction<bool> action)
    {
        scoreEvent.AddListener(action);
    }

    public void SetScorePerHit(MusicSong song)
    {
        var amount = song.ListBeats.Count;
        scorePerHit = 100f / amount;
        scorePerMultiplier = scorePerHit;

        Debug.Log("Score per hit: " + scorePerHit);
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
        scoreEvent.Invoke(true);
        scoreSound.PlaySound(direction);
        SetScoreText();
    }

    public void FailedScore()
    {
        multiplier = 1.0f;
        scoreSound.PlaySound(Direction.none);

        //SetScoreText();
    }

    public void DisplayHighscore()
    {
        foreach (var scoreText in ScoreText)
        {
            scoreText.SetScore(" " + Score.ToString("0.0") + "%"
                + "\nP1: " + ScoreP1.ToString("0.0") + "%"
                + "\nP2: " + ScoreP2.ToString("0.0") + "%");
        }
    }

    private void SetScoreText()
    {
        foreach (var scoreText in ScoreText)
        {
            scoreText.SetScore(" " + Score.ToString("0.0") + "%");
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
