using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour
{
    TextMesh text;

    public Color ColorLeft;
    public Color ColorRight;
    public Color ColorUp;
    public Color ColorDown;
    public Color ColorSpecial;
    public Color ColorNone;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    public void SetScore(string score)
    {
        this.text.text = score.ToString();
    }

    public void ChangeDirection(Direction dir)
    {
        this.text.color = GetColorDir(dir);
    }

    private Color GetColorDir(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return ColorUp;
            case Direction.down:
                return ColorDown;
            case Direction.left:
                return ColorLeft;
            case Direction.right:
                return ColorRight;
            case Direction.special:
                return ColorSpecial;
        }
        return ColorNone;
    }
}
