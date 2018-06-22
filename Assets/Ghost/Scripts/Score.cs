using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Score : MonoBehaviour
{

    public static Score instance;

    public Text countText;
    public Text ghostColorText;

    public UnityEngine.UI.Image prohibitedSign;

    public Text prohibitedInfo;

    public Text PowerUpNotAvailable;

    public Button refreshColor;

    public int _score;
    public int _caughtGhosts;
    private ArrayList _leaderBoardPoints;

    private void Awake()
    {
        if (instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }

        instance = this;
    }

    private void Start()
    {
        VuforiaBehaviour.Instance.enabled = true;
       
        SetCountText();
        _score = 0;
        _caughtGhosts = 0;
        prohibitedInfo.enabled = false;
        prohibitedSign.enabled = false;
        PowerUpNotAvailable.enabled = false;

        _leaderBoardPoints = new ArrayList();
        _leaderBoardPoints.Add("Player One Points");
        _leaderBoardPoints.Add("Player Two Points");
        _leaderBoardPoints.Add("Player Three Points");
        _leaderBoardPoints.Add("Player Four Points");
        _leaderBoardPoints.Add("Player Five Points");
        _leaderBoardPoints.Add("Player Six Points");
        _leaderBoardPoints.Add("Player Seven Points");

    }

    public void enablePowerup(bool yesnt)
    {
        PowerUpNotAvailable.enabled = yesnt;
    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the current score
    /// </summary>
	public void SetCountText()
    {
        countText.text = "Punkte: " + this._score.ToString();
    }

    /// <summary>
    /// Adding two points to the _score variable and updating the UI-Element displaying the current score
    /// </summary>
	public void Increment()
    {
        _score += 100;
        _caughtGhosts++;
        SetCountText();
    }

    /// <summary>
    /// Decreasing the number of points by 1 and updating the UI-Element displaying the current score
    /// </summary>
	public void Decrease()
    {
        if (_score != 0)
        {

            _score -= 50;
            SetCountText();

        }

    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the color of the last caught ghost
    /// </summary>
    /// <param name="ghostColor">color to display in the UI-Element</param>
	public void SetGhostColorText(string ghostColor)
    {
        ghostColorText.text = ghostColor;
    }

    public void AddScoreToLeaderboard(int score)
    {

        bool added = false;
        int point = 0;

        foreach (string lbPoint in _leaderBoardPoints)
        {
            if (added)
            {
                int tempPoint = PlayerPrefs.GetInt(lbPoint);
                PlayerPrefs.SetInt(lbPoint, point);
                point = tempPoint;
                continue;
            }
            point = PlayerPrefs.GetInt(lbPoint);
            if (score != 0 || score > point || !added)
            {
                PlayerPrefs.SetInt(lbPoint, score);
                added = true;
            }
        }
    }
    /// <summary>
    /// Enables the image ProhibitedSign
    /// </summary>
	public void ShowProhibited()
    {
        prohibitedSign.enabled = true;
        prohibitedInfo.enabled = true;
    }
}
