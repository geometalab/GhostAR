using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{

    public Text point;
    
    private void Start()
    {
        UpdateLeaderboardText();
    }

    private void UpdateLeaderboardText()
    {
        int savedPoint = PlayerPrefs.GetInt(point.name, 0);
        if (savedPoint != 0)
        {
            point.text = savedPoint.ToString();
        }
    }
}
