using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

	private bool _isCatched = false;
	private float _timeSinceCatched = 0;
	private Transform tf;
	private Vector3 originPosition;

	// Use this for initialization
	void Start ()
	{

		tf = gameObject.transform;
		originPosition = tf.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (_isCatched) {

			tf.position += Vector3.down;
			_timeSinceCatched += Time.deltaTime;

			if (_timeSinceCatched >= 3) {

				tf.position = originPosition;
				_isCatched = false;
				_timeSinceCatched = 0;

			}

		}
		
	}

	void OnMouseDown ()
	{
		_isCatched = true;
		GhostCatcher._colorOfLastCaughtGhost = "-";
		Score.instance.setGhostColorText ("-");
		Score.instance.decrease ();

	}
}
