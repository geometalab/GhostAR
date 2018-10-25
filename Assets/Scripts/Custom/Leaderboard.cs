using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private Text point;
    [SerializeField]
    private Text username;

    private void Start()
    {
        UpdateLeaderboardText();
    }

    public void UpdateLeaderboardText()
    {
        int savedPoint = PlayerPrefs.GetInt(point.name, 0);

        if (savedPoint != 0)
        {
            point.text = savedPoint.ToString();
        }
        else
        {
            point.text = "-";
        }

        string savedUsername = PlayerPrefs.GetString(username.name, "-");

        if (!string.IsNullOrEmpty(savedUsername))
        {
            username.text = savedUsername;
        }
    }
}
