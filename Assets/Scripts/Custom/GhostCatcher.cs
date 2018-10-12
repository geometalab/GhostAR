using UnityEngine;

public class GhostCatcher : MonoBehaviour
{

    private bool _isCaught = false;
    private float _timeSinceCatched = 0;
    // why public? why static?
    public static string colorOfLastCaughtGhost { get; set; }
    private string _ghostColor;

    private void Start()
    {
        colorOfLastCaughtGhost = " ";
        _ghostColor = gameObject.name.Split('_')[0];
    }

    private void Update()
    {
        if (_isCaught)
        {
            Transform transform = gameObject.transform;

            transform.Rotate(Vector3.forward * _timeSinceCatched * 10f);

            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 targetDestination = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z - 0.5f);

            transform.position = Vector3.MoveTowards(transform.position, targetDestination, 0.05f * _timeSinceCatched);
            transform.localScale *= 1f - Time.deltaTime * _timeSinceCatched * 1.5f;

            _timeSinceCatched += Time.deltaTime;

            if (transform.position == targetDestination)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (_isCaught)
        {
            return;
        }
        Score score = Score.s_instance;
        if (gameObject.name.StartsWith(colorOfLastCaughtGhost))
        {
            score.ShowProhibited();
            return;
        }
        score.Increment();
        score.SetGhostColorText(_ghostColor);
        GameObject.Find("ARCamera").GetComponent<HSR.GhostAR.GameTime.Countdown>().SetLastCaughtTime();
        colorOfLastCaughtGhost = _ghostColor;
        _isCaught = true;
    }
}