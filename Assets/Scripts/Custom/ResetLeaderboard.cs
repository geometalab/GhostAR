using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLeaderboard : MonoBehaviour {

    private Rect windowRect;
    private GUIStyle headerStyle;
    private GUIStyle labelStyle;
    private GUIStyle btnStyle;
    private GUIStyle titleStyle;
    private bool show;

    // Use this for initialization
    void Start () {

        show = false;

        windowRect = new Rect(
            (Screen.width - (Screen.width / 10 * 8)) / 2,
            (Screen.height - (Screen.height / 10 * 3)) / 2,
            (Screen.width / 10 * 8),
            (Screen.height / 100 * 20)
        );

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        show = true;
    }

    private void OnGUI()
    {
        headerStyle = new GUIStyle("window");
        labelStyle = new GUIStyle("label");
        btnStyle = new GUIStyle("button");
        titleStyle = new GUIStyle("label");

        headerStyle.border = new RectOffset(10, 10, 10, 10);

        titleStyle.fontSize = 60;
        titleStyle.alignment = TextAnchor.MiddleCenter;

        labelStyle.fontSize = 50;
        labelStyle.alignment = TextAnchor.MiddleCenter;

        btnStyle.fontSize = 40;

        if (show)
        {
            windowRect = GUI.Window(0, windowRect, DialogWindow, "", headerStyle);
        }
    }

    // This is the actual window.
    private void DialogWindow(int windowID)
    {
        float y = windowRect.height / 2;

        Rect titleRect = new Rect(
            5,
            5,
            windowRect.width,
            windowRect.height / 100 * 20
        );

        Rect questionRectangle = new Rect(
            5,
            5,
            windowRect.width,
            windowRect.height / 100 * 70
        );

        GUI.Label(titleRect, "Scoreboard zurücksetzen", titleStyle);
        GUI.Label(questionRectangle, "\n\nWillst du wirklich\ndas Scoreboard zurücksetzen?.", labelStyle);

        Rect yesButton = new Rect(
            windowRect.width / 2 + 10,
            windowRect.height / 100 * 70,
            windowRect.width / 2 - 20,
            (windowRect.height - (y + 2)) / 2
        );

        if (GUI.Button(yesButton, "Akzeptieren", btnStyle))
        {
            PlayerPrefs.DeleteAll();
            Leaderboard[] highscores = GameObject.Find("Canvas").GetComponents<Leaderboard>();

            foreach (Leaderboard highscore in highscores)
            {
                highscore.UpdateLeaderboardText();
            }

            show = false;
        }

        Rect noButton = new Rect(
            10,
            windowRect.height / 100 * 70,
            windowRect.width / 2 - 20,
            (windowRect.height - (y + 2)) / 2
        );

        if (GUI.Button(noButton, "Abbrechen", btnStyle))
        {
            show = false;
        }
    }
}
