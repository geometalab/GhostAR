using UnityEngine;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour
{
    [HideInInspector]
    public bool show;

    private int usages;
    private float timeShown;
    private GhostCatcher ghost;
    private Text PowerUpNo;
    private GhostCatcher[] ghostCatchers;
    private Rect windowRect;
    private GUIStyle headerStyle;
    private GUIStyle labelStyle;
    private GUIStyle btnStyle;
    private GUIStyle titleStyle;

    private void Start()
    {
        usages = 0;
        timeShown = 0f;
        show = false;
        PowerUpNo = GetComponent<Score>().PowerUpNotAvailable;
        ghostCatchers = FindObjectsOfType<GhostCatcher>();
        windowRect = new Rect(
            (Screen.width - (Screen.width / 10 * 8)) / 2,
            (Screen.height - (Screen.height / 10 * 3)) / 2,
            (Screen.width / 10 * 8),
            (Screen.height / 100 * 20)
        );
    }

    public void OnClick(GhostCatcher ghost)
    {
        if (usages < 3)
        {
            show = true;
            this.ghost = ghost;
        }
        else
        {
            PowerUpNo.enabled = true;
        }
    }

    public void Update()
    {
        if (PowerUpNo)
        {
            if (PowerUpNo.enabled)
            {
                timeShown += Time.deltaTime;

                if (timeShown >= 0.75f)
                {
                    PowerUpNo.enabled = false;
                    timeShown = 0f;
                }
            }
        }
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

        GUI.Label(titleRect, "Nutzung: " + usages + "/3", titleStyle);
        GUI.Label(questionRectangle, "\n\nWenn du diesen Geist fängst \r\nwirst du nur die halben Punkte bekommen.", labelStyle);

        Rect yesButton = new Rect(
            windowRect.width / 2 + 10,
            windowRect.height / 100 * 70,
            windowRect.width / 2 - 20,
            (windowRect.height - (y + 2)) / 2
        );

        if (GUI.Button(yesButton, "Akzeptieren", btnStyle))
        {
            usages++;
            foreach (GhostCatcher ghost in ghostCatchers)
            {
                ghost.ColorOfLastCaughtGhost = " ";
            }
            GetComponent<Score>().SetGhostColorText("-");
            GetComponent<Score>().DecreaseScore(50);
            show = false;
            GetComponent<EndScreen>().SetEndScreenInfo();
            if (ghost)
            {
                ghost.CatchGhost();
            }
            else
            {
                Debug.LogError("Couldn't find the ghost to catch");
            }
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

    public string GetUsagesAsString()
    {
        return usages.ToString();
    }
}
