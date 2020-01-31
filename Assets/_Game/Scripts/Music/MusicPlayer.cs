using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private BeatCountdown beatCountdown;
    private MusicSong musicSong;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        beatCountdown = FindObjectOfType<BeatCountdown>();
    }

    public void Play(MusicSong musicSong)
    {
        Debug.Log("PlayMusicSong");
        this.musicSong = musicSong;
        audioSource.clip = musicSong.song;
        audioSource.Play();
        beatCountdown.BeatStart();
    }

    public void Beat()
    {
        musicSong.Beat();
    }
}
