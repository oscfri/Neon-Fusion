﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1, 2)]
    public int PlayerNr = 1;

    private string suffix;
    string KeyUp;
    string KeyDown;
    string KeyLeft;
    string KeyRight;
    string KeySpecial;

    public Direction Direction { get; private set; }

    void Start()
    {
        SetNames();
    }

    private void Update()
    {
        Direction = GetDirectionPressed();
    }

    private void SetNames()
    {
        suffix = PlayerNr == 1 ? "P1" : "P2";
        KeyUp = "Up" + suffix;
        KeyDown = "Down" + suffix;
        KeyLeft = "Left" + suffix;
        KeyRight = "Right" + suffix;
        KeySpecial = "Special" + suffix;
    }

    public bool CheckDirection(Direction direction)
    {
        var dir = GetDirectionPressed();
        return dir == direction;
    }

    private Direction GetDirectionPressed()
    {
        if (Input.GetButton(KeyUp))
        {
            return Direction.up;
        }

        if (Input.GetButton(KeyDown))
        {
            return Direction.down;
        }

        if (Input.GetButton(KeyLeft))
        {
            return Direction.left;
        }

        if (Input.GetButton(KeyRight))
        {
            return Direction.right;
        }

        if (Input.GetButton(KeySpecial))
        {
            return Direction.special;
        }
        return Direction.none;
    }
}
