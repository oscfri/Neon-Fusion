using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool hasReloaded = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasReloaded && Input.GetButtonDown("Submit"))
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        hasReloaded = true;
        SceneManager.LoadScene("dz");
    }
}
