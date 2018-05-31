using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Score : MonoBehaviour
{

	public static Score instance;

	public Text countText;
	public Text ghostColorText;

	public UnityEngine.UI.Image endScreenBackground;
	public UnityEngine.UI.Image prohibitedSign;

	public Text FinalScore;
	public Text LastCatchedTime;

	private int _score = 0;

	void Start ()
	{
		VuforiaBehaviour.Instance.enabled = true;
		if (instance) {
			Debug.Log ("Warning: Overriding instance reference");
		}
			
		instance = this;
		setCountText ();
		endScreenBackground.enabled = false;
		prohibitedSign.enabled = false;
		FinalScore.enabled = false;
		LastCatchedTime.enabled = false;

	}

	void setCountText ()
	{
		countText.text = "Geister: " + this._score.ToString ();
	}

	public void increment ()
	{
		++_score;
		setCountText ();
	}

	public void setGhostColorText (string ghostColor)
	{
		ghostColorText.text = ghostColor;
	}

	public void activateEndScreen ()
	{

		VuforiaBehaviour.Instance.enabled = false;

		countText.enabled = false;
		ghostColorText.enabled = false;

		endScreenBackground.enabled = true;
		FinalScore.text = "Geister: " + _score;
		FinalScore.enabled = true;
		LastCatchedTime.enabled = true;
		PlayerPrefs.SetInt("Last Score", _score);

	}

	public void setTimeOfLastCaughtGhost (float time)
	{
		LastCatchedTime.text = "Letzter Geist:\n" + (Mathf.Ceil (time * 100) * 0.01).ToString () + " Sekunden\nvor Schluss";
	}

	public void showProhibitedSign ()
	{
		prohibitedSign.enabled = true;
		Debug.Log ("enabled");
	}
}
