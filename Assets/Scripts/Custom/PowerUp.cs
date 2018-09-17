using UnityEngine;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour
{
    public int usages;
    public static PowerUp s_instance;
    private float _timeShown = 0f;

    private Text PowerUpNo;


    private void Awake()
    {
        if (s_instance)
        {
            Debug.Log("Warning: Overriding instance reference");
        }
        s_instance = this;
    }

    private void Start()
    {
        usages = 0;
        PowerUpNo = Score.s_instance.PowerUpNotAvailable;
    }

    private void OnClick()
    {

        if(usages < 3)
        {
            show = true;
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
            GhostCatcher.colorOfLastCaughtGhost = " ";
            Score.s_instance.SetGhostColorText(" ");
            Score.s_instance.Decrease();
            show = false;
            EndScreen.s_instance.SetEndScreenInfo();
        }

        if (GUI.Button(new Rect(5, y + ((windowRect.height - y) / 2), windowRect.width - 10, (windowRect.height - (y + 2)) / 2), "No", btnStyle))
        {
            show = false;
        }
    }
}
