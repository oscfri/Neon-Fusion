using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowChecker : MonoBehaviour
{
    private List<Arrow> ListArrows;
    private ScoreCounter scoreCounter;

    public PlayerInput PlayerInput;

    public float Zinside;
    public float Zoutside;

    public void Start()
    {
        ListArrows = new List<Arrow>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    public void AddArrow(Arrow arrow)
    {
        ListArrows.Add(arrow);
    }

    public void RemoveArrow(Arrow arrow)
    {
        ListArrows.Remove(arrow);
    }

    private void CheckArrows()
    {
        foreach (var arrow in ListArrows)
        {
            if (PlayerInput.Direction == arrow.direction) {
                scoreCounter.AddScore(arrow.direction);
                ListArrows.Remove(arrow);
                arrow.Scored();
            }
        }
    }
}
