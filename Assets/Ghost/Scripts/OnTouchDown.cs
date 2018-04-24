using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTouchDown : MonoBehaviour
{
	void Update () {

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
			}

		}
	}
}
