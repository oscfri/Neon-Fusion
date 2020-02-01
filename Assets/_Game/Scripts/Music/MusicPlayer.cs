using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private BeatCountdown beatCountdown;
    private MusicSong musicSongP1;
    private MusicSong musicSongP2;
    public ArrowGenerator arrowGeneratorP1;
    public ArrowGenerator arrowGeneratorP2;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        beatCountdown = FindObjectOfType<BeatCountdown>();
    }

    public void Play(MusicSong musicSongP1, MusicSong musicSongP2)
    {
        Debug.Log("PlayMusicSong");
        this.musicSongP1 = musicSongP1;
        this.musicSongP2 = musicSongP2;
        this.musicSongP1.Reset();
        this.musicSongP2.Reset();
        audioSource.clip = musicSongP1.song;
        audioSource.Play();
        beatCountdown.BeatStart();
    }

    public void StopPlay()
    {
        audioSource.Stop();
        //Todo: Play elevator idle music here
        beatCountdown.BeatStop();
    }

    public void Beat()
    {
        BeatPlayer(musicSongP1, arrowGeneratorP1);
        BeatPlayer(musicSongP2, arrowGeneratorP2);
    }

    private void BeatPlayer(MusicSong musicSong, ArrowGenerator arrowGenerator)
    {
        var spawn = musicSong.GetAndCheckBeat();
        if (spawn.Item1 == true)
        {
            arrowGenerator.Spawn(spawn.Item2);

            if (musicSong.CurrentIndex >= musicSong.ListBeats.Count)
            {
                StopPlay();
            }
        }
    }
}
