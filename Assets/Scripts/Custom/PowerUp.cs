using UnityEngine;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour
{
    [HideInInspector]
    public bool show;
    [SerializeField]
    private GameObject panel;

    private int usages;
    private float timeShown;
    private GhostCatcher ghost;
    private Text PowerUpNo;
    private GhostCatcher[] ghostCatchers;
    private Rect windowRect;
    private Dialogue dialogue;

    private void Start()
    {
        usages = 0;
        timeShown = 0f;
        show = false;
        PowerUpNo = GetComponent<Score>().PowerUpNotAvailable;
        ghostCatchers = FindObjectsOfType<GhostCatcher>();
    }

    public void OnClick(GhostCatcher ghost)
    {
        if (usages < 3)
        {
            dialogue = new Dialogue(
                "Nutzung: " + usages + "/3",
                "\n\nWenn du diesen Geist fängst \r\nwirst du nur die halben Punkte bekommen.",
                "Akzeptieren",
                "Abbrechen"
            );
            panel.SetActive(true);
            show = true;
            this.ghost = ghost;
        }
        else
        {
            PowerUpNo.gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        if (PowerUpNo)
        {
            if (PowerUpNo.IsActive())
            {
                timeShown += Time.deltaTime;

                if (timeShown >= 0.75f)
                {
                    PowerUpNo.gameObject.SetActive(false);
                    timeShown = 0f;
                }
            }
        }

        if(dialogue != null)
        {
            if (!string.IsNullOrEmpty(dialogue.Decision))
            {
                if (dialogue.Decision == "true")
                {
                    ResetGhostColor();
                    dialogue.Decision = "";
                    panel.SetActive(false);
                }
                else
                {
                    show = false;
                    dialogue.Decision = "";
                    panel.SetActive(false);
                }
            }
        }
    }

    private void OnGUI()
    {
        if (show)
        {
            windowRect = GUI.Window(0, dialogue.WindowRect, dialogue.CreateDialogue, "", dialogue.HeaderStyle);
        }
    }
    
    private void ResetGhostColor()
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

    public string GetUsagesAsString()
    {
        return usages.ToString();
    }
}
