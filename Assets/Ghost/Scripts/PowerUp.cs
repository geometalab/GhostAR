using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	private bool _isCatched = false;
	private float _timeSinceCatched = 0;
	private MeshRenderer mr;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (_isCatched) {

			_timeSinceCatched += Time.deltaTime;

			if (_timeSinceCatched >= 2) {
			
				gameObject.GetComponent<Renderer> ().enabled = true;
				_isCatched = false;

			}

		}
		
	}

	void OnMouseDown()
	{
		gameObject.GetComponent<Renderer> ().enabled = false;
		_isCatched = true;
		GhostCatcher._colorOfLastCaughtGhost = "-";
	}
}
