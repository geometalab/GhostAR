using UnityEngine;
using UnityEngine.UI;

namespace HSR.GhostAR.GameTime
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField]
        private Text countDownText;
        private float totalTime;
        private float elapsedTime;
        private float lastCaughtTime;

        public bool GameHasEnded { get; set; }

        private void Start()
        {
            GameHasEnded = false;
            totalTime = 20f;
            lastCaughtTime = 0;
            elapsedTime = 0;
        }

        private void Update()
        {
            if (!GameHasEnded)
            {
                UpdateCountDownTextAndTime();

                if (elapsedTime >= totalTime - 1)
                {
                    GameHasEnded = true;
                }
            }
            else
            {
                EndScreen endScreen = GetComponent<EndScreen>();
                endScreen.SetEndScreenInfo();

                if (!GetComponent<EndScreen>().hasBeenBuilt)
                {
                    countDownText.enabled = false;
                    endScreen.baseScore = GetComponent<Score>().score;
                    endScreen.ActivateEndScreen();
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

        public int GetTimeBonus()
        {
            int timeBonus = Mathf.FloorToInt(totalTime - lastCaughtTime);

            if (timeBonus > 100)
            {
                return 100;
            }

            return timeBonus;
        }

        public float GetCentisecondOfLastCaughtGhost()
        {
            return Mathf.Ceil(lastCaughtTime * 100);
        }

        public void SetLastCaughtTime()
        {
            lastCaughtTime = elapsedTime;
        }
    }
}
