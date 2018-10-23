using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using HSR.GhostAR.GameTime;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image endScreenBackground;
    [SerializeField]
    private Text FinalScore;
    [SerializeField]
    private Text LastCaughtTime;
    [SerializeField]
    private RectTransform bar;
    [SerializeField]
    private Button backButton;

    [HideInInspector]
    public int baseScore;
    [HideInInspector]
    public bool hasBeenBuilt;
    private Score score;
    Countdown countdown;
    PowerUp powerUp;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<Score>();
        countdown = GetComponent<Countdown>();
        powerUp = GetComponent<PowerUp>();

        baseScore = 0;
        hasBeenBuilt = false;
        FinalScore.enabled = false;
        LastCaughtTime.enabled = false;
    }

    /// <summary>
    /// Method disabling the Vuforia instance and some UI-Elements
    /// After that it enables the UI-Elements used to display the final score and the remaining since the last caught ghost
    /// At the end it saves the current score with the PlayersPrefs Class to ensure that the score is not lost if the app would crash
    /// </summary>
	public void ActivateEndScreen()
    {
        if (!hasBeenBuilt)
        {
            VuforiaBehaviour.Instance.enabled = false;

            score.countText.enabled = false;
            score.ghostColorText.enabled = false;
            powerUp.show = false;
            bar.gameObject.SetActive(false);

            endScreenBackground.enabled = true;
            FinalScore.enabled = true;
            LastCaughtTime.enabled = true;
            int endscore = baseScore + countdown.GetTimeBonus();

            if (score.score > 0)
            {
                score.score = endscore;
            }

            score.AddScoreToLeaderboard(score.score);
        }
        SetEndScreenPoints();
        countdown.GameHasEnded = true;
        hasBeenBuilt = true;
    }

    /// <summary>
    /// Sets the points that the player got on the end screen. This is a separate function because the
    /// text will need to be changed even after the program has ended.
    /// </summary>
    public void SetEndScreenPoints()
    {
        FinalScore.text = "Punkte: " + score.score;
    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the remaining time since the last caught ghost
    /// </summary>
	public void SetEndScreenInfo()
    {
        if (score.caughtGhosts != 0)
        {
            LastCaughtTime.text = "Geister: " + score.caughtGhosts.ToString() + "\n";
            LastCaughtTime.text += "Benutzte PowerUps: " + powerUp.GetUsagesAsString();
        }
    }

    public void SetBackButtonActive()
    {
        backButton.gameObject.SetActive(true);
    }
}
