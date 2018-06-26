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
    private string _username;
    private InputField usernameInputField;
    public Button submitUsernameButton;

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
        _username = "Player Unknown";
        usernameInputField = UsernameInput.instance.InputFieldUsername;
        submitUsernameButton.gameObject.SetActive(false);
        submitUsernameButton.onClick.AddListener(OnSubmit);

        _leaderBoardPoints = new ArrayList();
        _leaderBoardPoints.Add("Player One Points");
        _leaderBoardPoints.Add("Player Two Points");
        _leaderBoardPoints.Add("Player Three Points");
        _leaderBoardPoints.Add("Player Four Points");
        _leaderBoardPoints.Add("Player Five Points");
        _leaderBoardPoints.Add("Player Six Points");
        _leaderBoardPoints.Add("Player Seven Points");

    }

    private void OnSubmit()
    {
        if (usernameInputField.text != "") {
            PlayerPrefs.SetString(_username, usernameInputField.text);
            usernameInputField.gameObject.SetActive(false);
            submitUsernameButton.gameObject.SetActive(false);
            EndScreen.instance.backButton.gameObject.SetActive(true);
        }
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
    /// Adding 100 points to the _score variable and updating the UI-Element displaying the current score
    /// </summary>
	public void Increment()
    {
        _score += 100;
        _caughtGhosts++;
        SetCountText();
    }

    /// <summary>
    /// Decreasing the number of points by 50 and updating the UI-Element displaying the current score
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
    /// Method that compares the score with the saved scores of the leaderboard. 
    /// If the user reached a score high enough for the leaderboard. 
    /// He will be added and the rest of the scores will be moved down.
    /// </summary>
    /// <param name="score">The score the user made</param>
    public void AddScoreToLeaderboard(int score)
    {

        bool added = false;
        int point = 0;
        string username = "";

        foreach (string lbPoint in _leaderBoardPoints)
        {
            string[] playerName = lbPoint.Split(' ');

            if (added)
            {
                int tempPoint = PlayerPrefs.GetInt(lbPoint);
                string tempUsername = PlayerPrefs.GetString(playerName[0] + " " + playerName[1]);
                PlayerPrefs.SetInt(lbPoint, point);
                PlayerPrefs.SetString(playerName[0] + " " + playerName[1], username);
                point = tempPoint;
                username = tempUsername;
                continue;
            }
            point = PlayerPrefs.GetInt(lbPoint);
            if (score != 0 && score > point && !added)
            {
                PlayerPrefs.SetInt(lbPoint, score);
                _username = playerName[0] + " " + playerName[1];
                added = true;
                submitUsernameButton.gameObject.SetActive(true);
                usernameInputField.gameObject.SetActive(true);
                Debug.Log("Score saved in leaderbaord");
            }
        }
        if (!added)
        {
            EndScreen.instance.backButton.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// Enables the image ProhibitedSign and the message beneath it
    /// </summary>
	public void ShowProhibited()
    {
        prohibitedSign.enabled = true;
        prohibitedInfo.enabled = true;
    }
}
