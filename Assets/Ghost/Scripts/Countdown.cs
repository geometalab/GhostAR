using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

	private float countdown = 0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		countdown += Time.deltaTime;

		if (countdown >= 5f) {

			SceneManager.LoadScene (0);

		}

	}
}
