using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonalBestButton : MonoBehaviour
{
    public GameObject personalBestPanel;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            personalBestPanel.SetActive(true);
        }
    }
}
