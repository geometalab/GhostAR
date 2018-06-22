using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class EndScreen : MonoBehaviour {

    public static EndScreen instance;

    public UnityEngine.UI.Image endScreenBackground;

    public Text FinalScore;
    public Text LastCaughtTime;

    Score score;

    public Button backButton;

    public int baseScore;
    public bool hasWaited;
    public bool hasBeenBuilt;

    public float _timeWaited;

    private void Awake()
    {
        if (instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }

        instance = this;
    }

    // Use this for initialization
    void Start () {

        score = Score.instance;

        baseScore = 0;
        hasWaited = false;

        hasBeenBuilt = false;
        backButton.gameObject.SetActive(false);


        endScreenBackground.enabled = false;
        FinalScore.enabled = false;
        LastCaughtTime.enabled = false;

        _timeWaited = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(Countdown.instance.gameHasEnded && hasBeenBuilt)
        {
            giveTimeBonus();
        }
	}
    /// <summary>
    /// Method disabling the Vuforia instance and some UI-Elements
    /// After that it enables the UI-Elements used to display the final score and the remaining since the last caught ghost
    /// At the end it saves the current score with the PlayersPrefs Class to ensure that the score is not lost if the app would crash
    /// </summary>
	public void ActivateEndScreen()
    {
        if(!hasBeenBuilt)
        {
            Debug.Log("End: " + PowerUp.instance.usages.ToString());
            VuforiaBehaviour.Instance.enabled = false;

            score.countText.enabled = false;
            score.ghostColorText.enabled = false;
            PowerUp.instance.show = false;
            score.refreshColor.gameObject.SetActive(false);

            endScreenBackground.enabled = true;
            FinalScore.enabled = true;
            LastCaughtTime.enabled = true;
            score.AddScoreToLeaderboard(score._score);
            backButton.gameObject.SetActive(true);

        }
        SetEndScreenPoints();
        Countdown.instance.gameHasEnded = true;
        hasBeenBuilt = true;
    }

    /// <summary>
    /// Sets the points that the player got on the end screen. This is a separate function because the
    /// text will need to be changed even after the program has ended.
    /// </summary>
    public void SetEndScreenPoints()
    {
        FinalScore.text = "Punkte: " + score._score;
    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the remaining time since the last caught ghost
    /// </summary>
	public void SetEndScreenInfo()
    {
        
        if(score._caughtGhosts != 0)
        {
            LastCaughtTime.text = "Geister: " + score._caughtGhosts.ToString() + "\n";
            LastCaughtTime.text += " Zeit: " + (Mathf.Ceil(Countdown.instance._lastCaughtTime * 100) * 0.01).ToString() + " Sekunden \n";
            LastCaughtTime.text += "Benutzte PowerUps: " + PowerUp.instance.usages.ToString();
        }
    }

    /// <summary>
    /// After the game has ended, this will wait 1 second and then add a time bonus to the score.
    /// The time bonus is 1 point per second the player had left when they caught the last ghost.
    /// </summary>
    public void giveTimeBonus()
    {
        if(score._caughtGhosts > 0)
        {
            if(!hasWaited)
            {
                _timeWaited += Time.deltaTime;
                if (_timeWaited >= 1f)
                {
                    hasWaited = true;
                    Debug.Log("Waited for 1 second.");
                }
                return;
            }

            int endscore = baseScore + Mathf.FloorToInt(Countdown.instance._totalTime - Countdown.instance._lastCaughtTime);
            if (score._score < endscore)
            {
                score._score++;
                SetEndScreenPoints();
                PlayerPrefs.SetInt("Last Score", score._score);
            }
        }
    }
}
