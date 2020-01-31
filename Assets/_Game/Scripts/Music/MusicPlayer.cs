using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private BeatCountdown beatCountdown;
    private MusicSong musicSong;
    private ArrowGenerator arrowGenerator;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        beatCountdown = FindObjectOfType<BeatCountdown>();
        arrowGenerator = FindObjectOfType<ArrowGenerator>();
    }

    public void Play(MusicSong musicSong)
    {
        Debug.Log("PlayMusicSong");
        this.musicSong = musicSong;
        this.musicSong.Reset();
        audioSource.clip = musicSong.song;
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
