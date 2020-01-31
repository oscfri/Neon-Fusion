using UnityEngine;
using System.Collections;

/// <summary>
/// Temp class for testing.
/// </summary>
public class NewGamePlay : MonoBehaviour
{
    public MusicSong musicSong;
    private bool hasStarted = false;
    MusicPlayer musicPlayer;

    // Use this for initialization
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void Update()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            musicPlayer.Play(musicSong);
        }
    }
}
