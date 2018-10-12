using UnityEngine;
using UnityEngine.UI;

namespace HSR.GhostAR.GameTime
{
    public class Countdown : MonoBehaviour
    {
        private float _totalTime;
        private float _elapsedTime;
        private float _lastCaughtTime;

        public bool gameHasEnded { get; set; }
        [SerializeField]
        private Text countDownText;

        public Countdown(float _totalTime, float _elapsedTime, float _lastCaughtTime, bool gameHasEnded, Text countDownText)
        {
            this._totalTime = _totalTime;
            this._elapsedTime = _elapsedTime;
            this._lastCaughtTime = _lastCaughtTime;
            this.gameHasEnded = gameHasEnded;
            this.countDownText = countDownText;
        }

        private void Start()
        {
            gameHasEnded = false;
            _totalTime = 20f;
            _lastCaughtTime = 0;
            _elapsedTime = 0;
        }

        private void Update()
        {
            if (!gameHasEnded)
            {
                UpdateCountDownTextAndTime();

                if (_elapsedTime >= _totalTime - 1)
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
            _elapsedTime += Time.deltaTime;
            countDownText.text = Mathf.FloorToInt(_totalTime - _elapsedTime).ToString();
        }

        public int GetTimeBonus()
        {
            int timeBonus = Mathf.FloorToInt(_totalTime - _lastCaughtTime);

            if (timeBonus > 100)
            {
                return 100;
            }

            return timeBonus;
        }

        public float GetCentisecondOfLastCaughtGhost()
        {
            return Mathf.Ceil(_lastCaughtTime * 100);
        }

        public void SetLastCaughtTime()
        {
            _lastCaughtTime = _elapsedTime;
        }
    }
}
