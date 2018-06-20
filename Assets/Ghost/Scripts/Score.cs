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

    public UnityEngine.UI.Image endScreenBackground;
    public UnityEngine.UI.Image prohibitedSign;

    public Text FinalScore;
    public Text LastCatchedTime;
    
    public Text PowerUpNotAvailable;

    public Button refreshColor;
    public Button backButton;

    public int _score;
    private int _caughtGhosts;
    private ArrayList _leaderBoardPoints;

    private void Start()
    {
        VuforiaBehaviour.Instance.enabled = true;
        if (instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }

        instance = this;
        SetCountText();
        _score = 0;
        _caughtGhosts = 0;
        endScreenBackground.enabled = false;
        prohibitedSign.enabled = false;
        FinalScore.enabled = false;
        LastCatchedTime.enabled = false;
        PowerUpNotAvailable.enabled = false;
        backButton.gameObject.SetActive(false);

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

    /// <summary>
    /// Method disabling the Vuforia instance and some UI-Elements
    /// After that it enables the UI-Elements used to display the final score and the remaining since the last caught ghost
    /// At the end it saves the current score with the PlayersPrefs Class to ensure that the score is not lost if the app would crash
    /// </summary>
	public void ActivateEndScreen()
    {
        Debug.Log("End: " + PowerUp.instance.usages.ToString());
        VuforiaBehaviour.Instance.enabled = false;

        countText.enabled = false;
        ghostColorText.enabled = false;
        PowerUp.instance.show = false;
        refreshColor.gameObject.SetActive(false);

        endScreenBackground.enabled = true;
        FinalScore.text = "Punkte: " + _score;
        FinalScore.enabled = true;
        LastCatchedTime.enabled = true;
        backButton.gameObject.SetActive(true);
        AddScoreToLeaderboard(_score);

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
            if (score != 0 && score > point && !added)
            {
                while (string.IsNullOrEmpty(UsernameInput.instance.Username)) { }
                PlayerPrefs.SetInt(lbPoint, score);
                string[] playerName = lbPoint.Split(' ');
                PlayerPrefs.SetString(playerName[0] + " " + playerName[1], UsernameInput.instance.Username);
                added = true;
            }
        }

    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the remaining time since the last caught ghost
    /// </summary>
    /// <param name="time">the time when the last ghost was caught</param>
	public void SetEndScreenInfo(float time)
    {
        LastCatchedTime.text = "Geister: " + _caughtGhosts.ToString() + "\n";
        LastCatchedTime.text += " Zeit: " + (Mathf.Ceil(time * 100) * 0.01).ToString() + " Sekunden \n";
        LastCatchedTime.text += "Benutzte PowerUps: " + PowerUp.instance.usages.ToString();
    }

    /// <summary>
    /// Enables the image ProhibitedSign
    /// </summary>
	public void ShowProhibitedSign()
    {
        prohibitedSign.enabled = true;
    }
}
