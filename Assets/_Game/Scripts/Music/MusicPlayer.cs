using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private BeatCountdown beatCountdown;
    private BeatCounter beatCounter;
    public MusicSong musicSongP1;
    private MusicSong musicSongP2;
    private WinScreen winScreen;
    public ArrowGenerator arrowGeneratorP1;
    public ArrowGenerator arrowGeneratorP2;

    private bool hasStarted = false;
    private bool isSpawnStopped = false;
    private float timeStopSpawn = 8f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        winScreen = FindObjectOfType<WinScreen>();
        beatCountdown = FindObjectOfType<BeatCountdown>();
        beatCounter = FindObjectOfType<BeatCounter>();
        beatCounter.Attach(InvokeBeat);
    }

    void OnDestroy()
    {
        beatCounter.Release(InvokeBeat);
    }

    public void Play(MusicSong musicSongP1, MusicSong musicSongP2)
    {
        this.musicSongP1 = musicSongP1;
        this.musicSongP2 = musicSongP2;
        this.musicSongP1.Reset();
        this.musicSongP2.Reset();
        audioSource.clip = musicSongP1.song;

        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.SetScorePerHit(musicSongP1);

        audioSource.Play();
        beatCountdown.BeatStart();
        hasStarted = true;
    }

    private void Update()
    {
        if (hasStarted && Input.GetButtonDown("Submit"))
        {
            StopPlay();
        }

        if (hasStarted)
        {
            if (!isSpawnStopped && audioSource.time >= audioSource.clip.length - timeStopSpawn)
            {
                StopSpawning();
            }
            if (!audioSource.isPlaying)
            {
                StopPlay();
            }
        }
    }

    private void StopSpawning()
    {
        isSpawnStopped = true;
        winScreen.StopSpawning();
    }

    public void StopPlay()
    {
        hasStarted = false;
        audioSource.Stop();
        //Todo: Play elevator idle music here
        beatCountdown.BeatStop();
        winScreen.Win();
    }

    void InvokeBeat(bool isLong)
    {
        if (isLong)
        {
            BeatPlayer(musicSongP1, arrowGeneratorP1);
            BeatPlayer(musicSongP2, arrowGeneratorP2);
        }
    }

    private void BeatPlayer(MusicSong musicSong, ArrowGenerator arrowGenerator)
    {
        var direction = musicSong.GetAndCheckBeat();
        if (direction != Direction.none)
        {
            arrowGenerator.Spawn(direction);

            if (musicSong.CurrentIndex >= musicSong.ListBeats.Count)
            {
                //StopPlay();
            }
        }
    }
}
