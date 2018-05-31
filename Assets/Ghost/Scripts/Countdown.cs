using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	public float _remainingTime { get; set; }
	public static Countdown instance;

	public Text countDownText;

	void Start ()
	{
		if (instance) {
			Debug.Log ("Warning: Overriding instance reference");
		}

		instance = this;
		_remainingTime = 30f;
	}

	void Update()
	{

		setCountDownTextAndTime();
		if (_remainingTime <= 0f) {

			countDownText.enabled = false;
			Score.instance.activateEndScreen ();

		}
	}

	void setCountDownTextAndTime ()
	{
		_remainingTime -= Time.deltaTime;
		countDownText.text = Mathf.FloorToInt (_remainingTime).ToString ();
	}
}
