using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    private bool hasReloaded = false;
    // Update is called once per frame
    void Update()
    {
        if (!hasReloaded && Input.GetButtonDown("ReloadScene"))
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("dz");
    }
}
