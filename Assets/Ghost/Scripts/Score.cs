using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public static Score instance;

	public Text countText;

	private int _score = 0;

	void Start ()
	{
		
		if (instance) {
			Debug.Log ("Warning: Overriding instance reference");
		}

		instance = this;
		setCountText ();
	}

	void setCountText ()
	{
		countText.text = "Count: " + this._score.ToString ();
	}

	public void increment ()
	{
		++_score;
		setCountText ();
	}
}
