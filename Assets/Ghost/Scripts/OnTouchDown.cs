using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class OnTouchDown : MonoBehaviour
{
	public Text countText;
	public Text countDownText;

	private int count;
	private float time;

	void Start()
	{
		VuforiaBehaviour.Instance.enabled = true;
		time = 30f;
		count = 0;
		setCountText ();
		setCountDownTextAndTime ();
	}

	void Update () {

		setCountDownTextAndTime ();
		RaycastHit hit = new RaycastHit();
		for (int i = 0; i < Input.touchCount; ++i) {
			Debug.Log (Input.GetTouch (i));
			Debug.Log ("touched");
			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				if (Physics.Raycast(ray, out hit)) {
					hit.transform.gameObject.SendMessage("OnMouseDown");
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Debug.Log (ray.ToString ());
			if (Physics.Raycast(ray, out hit)) {
				hit.transform.gameObject.SendMessage("OnMouseDown");
				count = count + 1;
				setCountText ();
			}

		}

		if (time <= 0f) {

			countDownText.enabled = false;
			VuforiaBehaviour.Instance.enabled = false;

		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}

	void setCountDownTextAndTime()
	{
		time = time - Time.deltaTime;
		countDownText.text = Mathf.FloorToInt(time).ToString();
	}
}
