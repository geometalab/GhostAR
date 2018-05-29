using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class OnTouchDown : MonoBehaviour
{
	public Text countDownText;

	private float _time;

	void Start ()
	{
		VuforiaBehaviour.Instance.enabled = true;
		_time = 30f;
		setCountDownTextAndTime ();
	}

	void Update ()
	{

		setCountDownTextAndTime ();
		RaycastHit hit = new RaycastHit ();
		for (int i = 0; i < Input.touchCount; ++i) {
			Debug.Log (Input.GetTouch (i));
			Debug.Log ("touched");
			if (Input.GetTouch (i).phase.Equals (TouchPhase.Began)) {
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				if (Physics.Raycast (ray, out hit)) {
					hit.transform.gameObject.SendMessage ("OnMouseDown");
				}
			}
		}

		if (_time <= 0f) {

			countDownText.enabled = false;
			VuforiaBehaviour.Instance.enabled = false;

		}
	}

	void setCountDownTextAndTime ()
	{
		_time = _time - Time.deltaTime;
		countDownText.text = Mathf.FloorToInt (_time).ToString ();
	}
}
