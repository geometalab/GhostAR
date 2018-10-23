using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

    private readonly string title;
    private readonly string question;
    private readonly string accept;
    private readonly string decline;

    public string Decision { get; set; }

    public Rect WindowRect { get; set; }
    public GUIStyle HeaderStyle { get; set; }
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

        WindowRect = new Rect(
            (Screen.width - (Screen.width / 10 * 8)) / 2,
            (Screen.height - (Screen.height / 10 * 3)) / 2,
            (Screen.width / 10 * 8),
            (Screen.height / 100 * 20)
        );
    }

    private void SetDialogueStyle()
    {
        HeaderStyle = new GUIStyle("window");
        labelStyle = new GUIStyle("label");
        btnStyle = new GUIStyle("button");
        titleStyle = new GUIStyle("label");

        HeaderStyle.border = new RectOffset(10, 10, 10, 10);

        titleStyle.fontSize = 60;
        titleStyle.alignment = TextAnchor.MiddleCenter;

        labelStyle.fontSize = 50;
        labelStyle.alignment = TextAnchor.MiddleCenter;

        btnStyle.fontSize = 40;
    }

    private void SetRectangles()
    {
        float y = WindowRect.height / 2;

        titleRect = new Rect(
            5,
            5,
            WindowRect.width,
            WindowRect.height / 100 * 20
        );

        questionRect = new Rect(
            5,
            5,
            WindowRect.width,
            WindowRect.height / 100 * 70
        );

        yesButton = new Rect(
            WindowRect.width / 2 + 10,
            WindowRect.height / 100 * 70,
            WindowRect.width / 2 - 20,
            (WindowRect.height - (y + 2)) / 2
        );

        noButton = new Rect(
            10,
            WindowRect.height / 100 * 70,
            WindowRect.width / 2 - 20,
            (WindowRect.height - (y + 2)) / 2
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
