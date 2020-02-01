using UnityEngine;
using System.Collections;

public class ScoreSoundAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false;
    // Use this for initialization

    private void Update()
    {
        if (isPlaying && !audioSource.isPlaying)
        {
            isPlaying = false;
            Destroy(gameObject);
        }
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        isPlaying = true;
    }
}
