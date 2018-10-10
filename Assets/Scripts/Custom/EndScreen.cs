using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using HSR.GhostAR.GameTime;

public class EndScreen : MonoBehaviour
{

    public static EndScreen s_instance;

    public UnityEngine.UI.Image endScreenBackground;

    public Text FinalScore;
    public Text LastCaughtTime;
    public Button backButton;

    public int baseScore;
    public bool hasWaited;
    public bool hasBeenBuilt;
    public float timeWaited;

    private Score _score;

    private void Awake()
    {
        if (s_instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }

        s_instance = this;
    }

    // Use this for initialization
    void Start()
    {
        _score = Score.s_instance;

        baseScore = 0;
        hasWaited = false;

        hasBeenBuilt = false;
        backButton.gameObject.SetActive(false);


        endScreenBackground.enabled = false;
        FinalScore.enabled = false;
        LastCaughtTime.enabled = false;

        timeWaited = 0;
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
            Debug.Log("End: " + PowerUp.s_instance.usages.ToString());
            VuforiaBehaviour.Instance.enabled = false;

            _score.countText.enabled = false;
            _score.ghostColorText.enabled = false;
            PowerUp.s_instance.show = false;
            _score.refreshColor.gameObject.SetActive(false);

            endScreenBackground.enabled = true;
            FinalScore.enabled = true;
            LastCaughtTime.enabled = true;
            int endscore = baseScore + Countdown.s_instance.GetTimeBonus();
            if (_score.score > 0)
            {
                _score.score = endscore;
            }
            _score.AddScoreToLeaderboard(_score.score);
        }
        SetEndScreenPoints();
        Countdown.s_instance.gameHasEnded = true;
        hasBeenBuilt = true;
    }

    /// <summary>
    /// Sets the points that the player got on the end screen. This is a separate function because the
    /// text will need to be changed even after the program has ended.
    /// </summary>
    public void SetEndScreenPoints()
    {
        FinalScore.text = "Punkte: " + _score.score;
    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the remaining time since the last caught ghost
    /// </summary>
	public void SetEndScreenInfo()
    {

        if (_score.caughtGhosts != 0)
        {
            LastCaughtTime.text = "Geister: " + _score.caughtGhosts.ToString() + "\n";
            LastCaughtTime.text += " Zeit: " + (Countdown.s_instance.GetCentisecondOfLastCaughtGhost() * 0.01).ToString() + " Sekunden \n";
            LastCaughtTime.text += "Benutzte PowerUps: " + PowerUp.s_instance.usages.ToString();
        }
    }
}
