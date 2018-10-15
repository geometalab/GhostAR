using UnityEngine;

public class GhostCatcher : MonoBehaviour
{
    private bool isCaught = false;
    private float timeSinceCatch = 0;
    public string ColorOfLastCaughtGhost { get; set; }
    private GhostCatcher[] ghosts;
    private string ghostColor;

    private void Start()
    {
        ColorOfLastCaughtGhost = " ";
        ghosts = FindObjectsOfType<GhostCatcher>();
        ghostColor = gameObject.name.Split('_')[0];
    }

    private void Update()
    {
        if (isCaught)
        {
            Transform transform = gameObject.transform;

            transform.Rotate(Vector3.forward * timeSinceCatch * 10f);

            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 targetDestination = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z - 0.5f);

            transform.position = Vector3.MoveTowards(transform.position, targetDestination, 0.05f * timeSinceCatch);
            transform.localScale *= 1f - Time.deltaTime * timeSinceCatch * 1.5f;

            timeSinceCatch += Time.deltaTime;

            if (transform.position == targetDestination)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (isCaught)
        {
            return;
        }
        Score score = GameObject.Find("ARCamera").GetComponent<Score>();
        if (gameObject.name.StartsWith(ColorOfLastCaughtGhost))
        {
            score.ShowProhibited();
            return;
        }
        score.Increment();
        score.SetGhostColorText(ghostColor);
        GameObject.Find("ARCamera").GetComponent<HSR.GhostAR.GameTime.Countdown>().SetLastCaughtTime();
        foreach(GhostCatcher ghost in ghosts)
        {
            ghost.ColorOfLastCaughtGhost = ghostColor;
        }
        isCaught = true;
    }
}