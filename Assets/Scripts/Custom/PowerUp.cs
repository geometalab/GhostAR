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

    private void Start()
    {
        usages = 0;
        timeShown = 0f;
        show = false;
        PowerUpNo = GetComponent<Score>().PowerUpNotAvailable;
        ghostCatchers = FindObjectsOfType<GhostCatcher>();
        windowRect = new Rect((Screen.width - (Screen.width / 10 * 8)) / 2, (Screen.height - (Screen.height / 10 * 6)) / 2, (Screen.width / 10 * 8), (Screen.height / 100 * 25));
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

        headerStyle.border = new RectOffset(10, 10, 10, 10);

        labelStyle.fontSize = 40;
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
        float y = windowRect.height / 5;
        GUI.Label(new Rect(5, 5, windowRect.width, 100), "Do you really want to spend 50 points" + "\r\n" + "to reset the last ghost's color?", labelStyle);

        if (GUI.Button(new Rect(5, y, windowRect.width - 10, (windowRect.height - (y + 2)) / 2), "Yes", btnStyle))
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

        if (GUI.Button(new Rect(5, y + ((windowRect.height - y) / 2), windowRect.width - 10, (windowRect.height - (y + 2)) / 2), "No", btnStyle))
        {
            show = false;
        }
    }

    public string GetUsagesAsString()
    {
        return usages.ToString();
    }
}
