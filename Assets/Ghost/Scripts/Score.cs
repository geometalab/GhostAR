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

    private int _score = 0;
    private float _waitingTime = 0f;

    private void Start()
    {
        VuforiaBehaviour.Instance.enabled = true;
        if (instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }

        instance = this;
        SetCountText();
        endScreenBackground.enabled = false;
        prohibitedSign.enabled = false;
        FinalScore.enabled = false;
        LastCatchedTime.enabled = false;

    }

    private void Update()
    {

        if (_score >= 2)
        {
            _waitingTime += Time.deltaTime;

            if (_waitingTime >= 4)
            {
                ActivateEndScreen();
            }

        }

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
        _score++;
        SetCountText();
    }

    /// <summary>
    /// Decreasing the number of points by 1 and updating the UI-Element displaying the current score
    /// </summary>
	public void Decrease()
    {
        if (_score != 0)
        {

            --_score;
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

        VuforiaBehaviour.Instance.enabled = false;

        countText.enabled = false;
        ghostColorText.enabled = false;

        endScreenBackground.enabled = true;
        FinalScore.text = "Geister: " + _score;
        FinalScore.enabled = true;
        PlayerPrefs.SetInt("Last Score", _score);

    }

    /// <summary>
    /// Setting the text for the UI-Element displaying the remaining time since the last caught ghost
    /// </summary>
    /// <param name="time">the time when the last ghost was caught</param>
	public void SetTimeOfLastCaughtGhost(float time)
    {
        LastCatchedTime.text = "Letzter Geist:\n" + (Mathf.Ceil(time * 100) * 0.01).ToString() + " Sekunden\nvor Schluss";
    }

    /// <summary>
    /// Enables the image ProhibitedSign
    /// </summary>
	public void ShowProhibitedSign()
    {
        prohibitedSign.enabled = true;
    }
}
