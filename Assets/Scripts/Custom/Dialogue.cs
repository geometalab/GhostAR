using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

    private string title;
    private string question;
    private string accept;
    private string decline;

    private Rect windowRect;
    private GUIStyle headerStyle;
    private GUIStyle labelStyle;
    private GUIStyle btnStyle;
    private GUIStyle titleStyle;
    private Rect titleRect;
    private Rect questionRect;
    private Rect yesButton;
    private Rect noButton;

    public Dialogue(string title, string question, string accept, string decline)
    {
        this.title = title;
        this.question = question;
        this.accept = accept;
        this.decline = decline;

        windowRect = new Rect(
            (Screen.width - (Screen.width / 10 * 8)) / 2,
            (Screen.height - (Screen.height / 10 * 3)) / 2,
            (Screen.width / 10 * 8),
            (Screen.height / 100 * 20)
        );
    }

    private void SetDialogueStyle()
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
    }

    private void SetRectangles()
    {
        float y = windowRect.height / 2;

        titleRect = new Rect(
            5,
            5,
            windowRect.width,
            windowRect.height / 100 * 20
        );

        questionRect = new Rect(
            5,
            5,
            windowRect.width,
            windowRect.height / 100 * 70
        );

        yesButton = new Rect(
            windowRect.width / 2 + 10,
            windowRect.height / 100 * 70,
            windowRect.width / 2 - 20,
            (windowRect.height - (y + 2)) / 2
        );

        noButton = new Rect(
            10,
            windowRect.height / 100 * 70,
            windowRect.width / 2 - 20,
            (windowRect.height - (y + 2)) / 2
        );
    }
    
    public void CreateDialogue(int windowID)
    {
        SetDialogueStyle();
        SetRectangles();

        GUI.Label(titleRect, title, titleStyle);
        GUI.Label(questionRect, question, labelStyle);        

        if (GUI.Button(yesButton, accept, btnStyle))
        {
            //return some value
        }

        if (GUI.Button(noButton, decline, btnStyle))
        {
            //return some value
        }
    }
}
