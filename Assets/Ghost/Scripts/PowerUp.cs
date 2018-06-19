using UnityEngine;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour
{
    public int usages { get; set;  }
    public static PowerUp instance;
    private float _timeShown = 0f;

    private Text PowerUpNo;

    public void Start()
    {
        if (instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }
        instance = this;
        usages = 0;
        PowerUpNo = Score.instance.PowerUpNotAvailable;
    }

    private void OnClick()
    {

        if(usages < 3)
        {
            show = true;
            OnGUI();
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
                _timeShown += Time.deltaTime;

                if (_timeShown >= 0.75f)
                {

                    Debug.Log("disabled");
                    PowerUpNo.enabled = false;

                    _timeShown = 0f;
                }
            }
        }
    }


    private Rect windowRect = new Rect((Screen.width - (Screen.width / 10 * 8)) / 2, (Screen.height - (Screen.height / 10 * 6)) / 2, (Screen.width / 10 * 8), (Screen.height / 100 * 25));
    // Only show it if needed.
    public bool show = false;
    public GUIStyle headerStyle;
    public GUIStyle labelStyle;
    public GUIStyle btnStyle;

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
            windowRect = GUI.Window(0, windowRect, DialogWindow, "", headerStyle);
    }

    // This is the actual window.
    private void DialogWindow(int windowID)
    {
        
        float y = windowRect.height / 5;
        GUI.Label(new Rect(5, 5, windowRect.width, 100), "Do you really want to spend 50 points" + "\r\n" + "to reset the last ghost's color?", labelStyle);


        if (GUI.Button(new Rect(5, y, windowRect.width - 10, (windowRect.height - (y + 2)) / 2), "Yes", btnStyle))
        {
            usages++;
            Score.instance.SetEndScreenInfo(Countdown.instance._lastCaughtTime);
            GhostCatcher._colorOfLastCaughtGhost = " ";
            Score.instance.SetGhostColorText(" ");
            Score.instance.Decrease();
            Debug.Log("Color reset");
            Debug.Log(usages.ToString());
            show = false;
        }

        if (GUI.Button(new Rect(5, y + ((windowRect.height - y) / 2), windowRect.width - 10, (windowRect.height - (y + 2)) / 2), "No", btnStyle))
        {
            show = false;
        }
    }
}
