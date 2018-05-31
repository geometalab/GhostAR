using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour {

	public Text lastScoreText;

	// Use this for initialization
	void Start () {
		lastScoreText.text = "Letzte Session: " + PlayerPrefs.GetInt("Last Score", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
