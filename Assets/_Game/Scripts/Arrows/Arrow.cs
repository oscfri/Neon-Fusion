using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up, down, left, right, special, none
}

enum ArrowState
{
    idle,
    inside,
    outside,
    destroyed
}

public class Arrow : MonoBehaviour
{
    public Direction direction;
    private ArrowChecker arrowChecker;

    private ArrowState state;

    private float zInside;
    private float zOutside;


    public void SetArrowChecker(ArrowChecker checker)
    {
        state = ArrowState.idle;
        arrowChecker = checker;

        zInside = checker.Zinside;
        zOutside = checker.Zoutside;
    }

    void Update()
    {
        if (arrowChecker != null && state != ArrowState.destroyed)
        {
            if (state == ArrowState.idle)
            {
                if (transform.position.z <= zInside)
                {
                    state = ArrowState.inside;
                    arrowChecker.AddArrow(this);
                }
            }
            else if (state == ArrowState.inside)
            {
                if (transform.position.z <= zOutside)
                {
                    SetOutside();
                }
            }
        }
    }

    private void SetOutside()
    {
        //Todo: add effects when outside
        state = ArrowState.outside;
        arrowChecker.RemoveArrow(this);
    }

    /// <summary>
    /// Kills the arrow.
    /// </summary>
    public void Scored()
    {
        state = ArrowState.destroyed;
        Destroy(this);
    }
}
