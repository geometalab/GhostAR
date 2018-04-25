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
			// transform.localScale *= 1f - Time.deltaTime * 0.4f;
			transform.Rotate (Vector3.forward * timeSinceCatched * 10f);
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 targetDestination = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z - 0.5f);
			transform.position = Vector3.MoveTowards(transform.position, targetDestination, 0.05f * timeSinceCatched);
			transform.localScale *= 1f - Time.deltaTime * timeSinceCatched * 1.5f;

			timeSinceCatched += Time.deltaTime;

			if (transform.position == targetDestination) {
				Debug.Log (obj_name + " was destroyed");
				Destroy (gameObject);
			}
		}

	}

	void OnMouseDown(){

		Debug.Log ("OMD " + obj_name);
		isCatched = true;
	}
}