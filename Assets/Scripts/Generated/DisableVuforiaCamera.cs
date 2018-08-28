using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DisableVuforiaCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
