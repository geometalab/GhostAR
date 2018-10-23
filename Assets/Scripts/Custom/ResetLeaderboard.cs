using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLeaderboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
        Leaderboard[] highscores = GameObject.Find("Canvas").GetComponents<Leaderboard>();

        Debug.Log(highscores.Length);

        foreach(Leaderboard highscore in highscores)
        {
            highscore.UpdateLeaderboardText();
        }
    }
}
