using UnityEngine;
using System.Collections;

public class GhostCatcher : MonoBehaviour {

	bool isCatched = false;
	float timeSinceCatched = 0;
	Material originalMaterial;
	Material redMaterial;
	MeshRenderer meshRenderer;

	GameObject baseObject;
	string obj_name;
	// Use this for initialization
	void Start () {

		obj_name 			= this.gameObject.name + "Base";
	}

	// Update is called once per frame
	void Update () {

		if (isCatched) {
			Transform transform = gameObject.transform;
			transform.localScale *= 1f - Time.deltaTime * 0.4f;
			transform.Rotate (Vector3.forward * timeSinceCatched * 5f);

			timeSinceCatched += Time.deltaTime;

			if (timeSinceCatched > 5) {
				Destroy (gameObject);
			}
		}

	}

	void OnMouseDown(){

		Debug.Log ("OMD " + obj_name);
		isCatched = true;
	}
}