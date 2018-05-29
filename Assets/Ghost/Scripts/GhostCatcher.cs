using UnityEngine;
using System.Collections;

public class GhostCatcher : MonoBehaviour
{

	private bool _isCatched = false;
	private float _timeSinceCatched = 0;

	private static string _colorOfLastCaughtGhost = "undefined";

	private string _ghostColor;

	// Use this for initialization
	void Start ()
	{
		_ghostColor = gameObject.name.Split ('_') [0];
	}

	// Update is called once per frame
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
		if (gameObject.name.StartsWith (_colorOfLastCaughtGhost)) {
		
			return;

		}

		Score.instance.increment ();

		_colorOfLastCaughtGhost = _ghostColor;

		_isCatched = true;

	}
}