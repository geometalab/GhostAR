using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float _remainingTime { get; set; }
    public static Countdown instance;

    public Text countDownText;

    private void Start()
    {
        if (instance)
        {
            Debug.LogWarning("Warning: Overriding instance reference");
        }

        instance = this;
        countDownText.enabled = false;
    }

    private void Update()
    {

    }

    /// <summary>
    /// Calculates the remaining time and updates the UI-Element displaying the time by flooring and parsing the float number into a String
    /// </summary>
	public void SetCountDownTextAndTime()
    {
        _remainingTime -= Time.deltaTime;
        countDownText.text = Mathf.FloorToInt(_remainingTime).ToString();
    }
}
