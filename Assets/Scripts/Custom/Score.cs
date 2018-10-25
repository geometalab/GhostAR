using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text usernamePrompt; 
    public Text countText;
    public Text ghostColorText;
    public Text PowerUpNotAvailable;

    [SerializeField]
    private Button submitUsernameButton;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int caughtGhosts;

    private ArrayList leaderBoardPoints;
    private string arrayListValueOfHighscore;
    private float timeShown;
    [SerializeField]
    private InputField usernameInputField;

    private void Start()
    {
        VuforiaBehaviour.Instance.enabled = true;

        UpdateCountText();
        score = 0;
        timeShown = 0f;
        caughtGhosts = 0;
        arrayListValueOfHighscore = "Player Unknown";
        submitUsernameButton.onClick.AddListener(OnSubmit);

        leaderBoardPoints = new ArrayList
        {
            "Player One Points",
            "Player Two Points",
            "Player Three Points",
            "Player Four Points",
            "Player Five Points",
            "Player Six Points",
            "Player Seven Points"
        };
    }

    private void Update()
    {
        if (usernamePrompt.IsActive())
        {
            timeShown += Time.deltaTime;

            if(timeShown >= 0.75f)
            {
                usernamePrompt.gameObject.SetActive(false);
                timeShown = 0f;
            }
        }
    }

    private void OnSubmit()
    {
        if (usernameInputField.text != "")
        {
            PlayerPrefs.SetString(arrayListValueOfHighscore, usernameInputField.text);
            usernameInputField.gameObject.SetActive(false);
            submitUsernameButton.gameObject.SetActive(false);
            GetComponent<EndScreen>().SetBackButtonActive();
        }
        else
        {
            usernamePrompt.gameObject.SetActive(true);
        }
    }

    public void EnablePowerup(bool yesnt)
    {
        PowerUpNotAvailable.enabled = yesnt;
    }
    
	public void UpdateCountText()
    {
        countText.text = "Punkte: " + this.score.ToString();
    }
    
	public void IncrementScore(int points)
    {
        score += points;
        caughtGhosts++;
        UpdateCountText();
    }
    
	public void DecreaseScore(int points)
    {
        if (score != 0)
        {
            score -= points;
            UpdateCountText();
        }
    }
    
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

        foreach (string lbPoint in leaderBoardPoints)
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

                arrayListValueOfHighscore = playerName[0] + " " + playerName[1];
                username = PlayerPrefs.GetString(playerName[0] + " " + playerName[1]);

                added = true;

                submitUsernameButton.gameObject.SetActive(true);
                usernameInputField.gameObject.SetActive(true);
            }
        }

        if (!added)
        {
            GetComponent<EndScreen>().SetBackButtonActive();
        }
    }
}
