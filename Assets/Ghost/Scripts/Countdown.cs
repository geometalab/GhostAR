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

    private void Start()
    {
        _totalTime = 7f;
        _lastCaughtTime = 0;
        if (instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }

        instance = this;
        _elapsedTime = 0;
    }

    private void Update()
    {

        SetCountDownTextAndTime();
        if (_elapsedTime >= _totalTime)
        {
            
            if (countDownText.enabled)
            {

                countDownText.enabled = false;
                Score.instance._score += Mathf.FloorToInt(_lastCaughtTime);
                Score.instance.ActivateEndScreen();

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
