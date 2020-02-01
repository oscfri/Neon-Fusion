using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    private Text text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(float score, float multiplier)
    {
        text.text = score + " - x" + multiplier;
    }
}
