using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text point;
    public Text username;

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

        string savedUsername = PlayerPrefs.GetString(username.name, "");

        if (!string.IsNullOrEmpty(savedUsername))
        {
            username.text = savedUsername;
        }
    }
}
