using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardButton : MonoBehaviour
{
    public GameObject leaderboardPanel;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leaderboardPanel.SetActive(true);
        }
    }

}
