using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float totalTime;
    public float elapsedTime { get; set; }
    public float lastCaughtTime;

    public bool gameHasEnded;
    public bool hasWaited;

    public Text countDownText;

    public static Countdown s_instance;

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
        gameHasEnded = false;
        totalTime = 5f;
        lastCaughtTime = 0;
        hasWaited = false;
        elapsedTime = 0;
    }

    private void Update()
    {
        if (!gameHasEnded)
        {
            UpdateCountDownTextAndTime();
            if (elapsedTime >= totalTime - 1)
            {
                gameHasEnded = true;
            }
        }
        else
        {
            EndScreen.s_instance.SetEndScreenInfo();
            if (!EndScreen.s_instance.hasBeenBuilt)
            {
                countDownText.enabled = false;
                EndScreen.s_instance.baseScore = Score.s_instance.score;
                EndScreen.s_instance.ActivateEndScreen();
            }
        }
    }

    /// <summary>
    /// Calculates the remaining time and updates the UI-Element displaying the time by flooring and parsing the float number into a String
    /// </summary>
	public void UpdateCountDownTextAndTime()
    {
        elapsedTime += Time.deltaTime;
        countDownText.text = Mathf.FloorToInt(totalTime - elapsedTime).ToString();
    }
}
