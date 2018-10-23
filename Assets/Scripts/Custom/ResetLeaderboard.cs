using UnityEngine;

public class ResetLeaderboard : MonoBehaviour
{

    private bool show;
    private Dialogue dialogue;
    [SerializeField]
    private GameObject panel;

    // Use this for initialization
    void Start()
    {
        show = false;
        dialogue = new Dialogue("Scoreboard zurücksetzen", "\nWillst du wirklich\ndas Scoreboard zurücksetzen?", "Akzeptieren", "Abbrechen");
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(dialogue.Decision))
        {
            if (dialogue.Decision == "true")
            {
                LeaderboardReset();
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

    public void OnClick()
    {
        panel.SetActive(true);
        show = true;
    }

    private void OnGUI()
    {
        if (show)
        {
            Rect windowRect = GUI.Window(0, dialogue.WindowRect, dialogue.CreateDialogue, "", dialogue.HeaderStyle);
        }
    }

    private void LeaderboardReset()
    {
        PlayerPrefs.DeleteAll();
        Leaderboard[] highscores = GameObject.Find("Canvas").GetComponents<Leaderboard>();

        foreach (Leaderboard highscore in highscores)
        {
            highscore.UpdateLeaderboardText();
        }

        show = false;
    }
}
