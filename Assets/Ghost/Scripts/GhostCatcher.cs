using UnityEngine;
using System.Collections;

public class GhostCatcher : MonoBehaviour
{

	private bool _isCatched = false;
	private float _timeSinceCatched = 0;

	public static string _colorOfLastCaughtGhost{ get; set; }

	private string _ghostColor;

	void Start ()
	{
		_colorOfLastCaughtGhost = "-";
		_ghostColor = gameObject.name.Split ('_') [0];
	}

	void Update ()
	{

		if (_isCatched) {

			Transform transform = gameObject.transform;
			transform.Rotate (Vector3.forward * _timeSinceCatched * 10f);
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 targetDestination = new Vector3 (cameraPosition.x, cameraPosition.y, cameraPosition.z - 0.5f);
			transform.position = Vector3.MoveTowards (transform.position, targetDestination, 0.05f * _timeSinceCatched);
			transform.localScale *= 1f - Time.deltaTime * _timeSinceCatched * 1.5f;

			_timeSinceCatched += Time.deltaTime;

			if (transform.position == targetDestination) {
				
				Destroy (gameObject);

			}

		}

	}

	void OnMouseDown ()
	{
		if (_isCatched) {
			return;
		}
		Score score = Score.instance;
		if (gameObject.name.StartsWith (_colorOfLastCaughtGhost)) {
		
			score.showProhibitedSign ();
			return;

		}

		score.increment ();
		score.setGhostColorText (_ghostColor);

		score.setTimeOfLastCaughtGhost(Countdown.instance._remainingTime);

		_colorOfLastCaughtGhost = _ghostColor;

		_isCatched = true;

	}
}