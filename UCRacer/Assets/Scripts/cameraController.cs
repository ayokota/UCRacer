using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public GameObject cameraLocation;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 velocity = Vector3.zero;
		Vector3 forward = cameraLocation.transform.forward * 5.0f;
		Vector3 needPos = cameraLocation.transform.position - forward;
		needPos.y = 3.0f;
		transform.position = Vector3.SmoothDamp(transform.position, needPos,
		                                        ref velocity,0.06f);
		transform.LookAt (cameraLocation.transform);
	}
}
