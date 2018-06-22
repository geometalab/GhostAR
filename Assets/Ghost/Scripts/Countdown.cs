using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float _totalTime;
    public float _elapsedTime { get; set; }
    public float _lastCaughtTime;
    public static Countdown instance;

    public Text countDownText;

    public bool gameHasEnded;

    public bool hasWaited;

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
        gameHasEnded = false;
        _totalTime = 300f;
        _lastCaughtTime = 0;

        hasWaited = false;

        _elapsedTime = 0;
    }

    private void Update()
    {
        if (!gameHasEnded)
        {
            SetCountDownTextAndTime();
            if (_elapsedTime >= _totalTime - 1)
            {
                gameHasEnded = true;
            }
        }
        else
        {
            EndScreen.instance.SetEndScreenInfo();
            if(!EndScreen.instance.hasBeenBuilt)
            {
                countDownText.enabled = false;
                EndScreen.instance.baseScore = Score.instance._score;
                EndScreen.instance.ActivateEndScreen();
            }
        }
    }

    /// <summary>
    /// Calculates the remaining time and updates the UI-Element displaying the time by flooring and parsing the float number into a String
    /// </summary>
	public void SetCountDownTextAndTime()
    {
        _elapsedTime += Time.deltaTime;
        countDownText.text = Mathf.FloorToInt(_totalTime - _elapsedTime).ToString();
    }
}
