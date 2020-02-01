using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorSelector : MonoBehaviour
{
    public Material ColorLeft;
    public Material ColorRight;
    public Material ColorUp;
    public Material ColorDown;
    public Material ColorSpecial;
    public Material ColorNone;

    MeshRenderer[] render;

    // Use this for initialization
    void Start()
    {
        render = GetComponentsInChildren<MeshRenderer>();
    }

    public void ChangeDirection(Direction dir)
    {
        foreach (var rend in render)
        {
            rend.material = GetMat(dir);
        }
    }

    private Material GetMat(Direction direction)
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
