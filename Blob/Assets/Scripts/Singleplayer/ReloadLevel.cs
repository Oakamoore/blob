using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reload level.");
            SceneManager.LoadScene("SingleplayerLevel");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit level.");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
