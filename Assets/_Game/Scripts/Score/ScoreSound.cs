using UnityEngine;
using System.Collections;

public class ScoreSound : MonoBehaviour
{
    public AudioClip soundLeft;
    public AudioClip soundRight;
    public AudioClip soundUp;
    public AudioClip soundDown;
    public AudioClip soundSpecial;

    public ScoreSoundAudio ScoreSoundAudio;

    public void PlaySound(Direction dir)
    {
        switch (dir)
        {
            case Direction.up:
                PlaySound(soundUp);
                break;
            case Direction.down:
                PlaySound(soundDown);
                break;
            case Direction.left:
                PlaySound(soundLeft);
                break;
            case Direction.right:
                PlaySound(soundRight);
                break;
            case Direction.special:
                PlaySound(soundSpecial);
                break;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        var child = Instantiate(ScoreSoundAudio, transform);
        child.PlayClip(clip);
    }
}
