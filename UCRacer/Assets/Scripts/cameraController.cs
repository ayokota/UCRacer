using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public GameObject cameraLocation;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = cameraLocation.transform.position;
		transform.rotation = cameraLocation.transform.rotation;
	}
}
