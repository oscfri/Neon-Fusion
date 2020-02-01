using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowChecker : MonoBehaviour
{
    private List<Arrow> ListArrows;
    private ScoreCounter scoreCounter;

    public ParticleSystem Explosion;
    public PlayerInput PlayerInput;

    public float Zinside;
    public float Zoutside;

    public void Start()
    {
        ListArrows = new List<Arrow>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void Update()
    {
        CheckArrows();
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
        for (int i = 0; i < ListArrows.Count; i++)
        {
            var arrow = ListArrows[i];
            if (PlayerInput.Direction == arrow.direction) {
                scoreCounter.AddScore(arrow.direction, PlayerInput.PlayerNr);
                ListArrows.RemoveAt(i);

                if (Explosion)
                {
                    var explosion = Instantiate(Explosion, arrow.transform.position + transform.up * 2.0f, Quaternion.identity, transform);
                    var rendererComponent = explosion.GetComponent<Renderer>();
                    rendererComponent.material.SetColor("_EmissionColor", new Color(arrow.color.r, arrow.color.g, arrow.color.b));
                }

                arrow.Scored();
            }
        }
    }
}
