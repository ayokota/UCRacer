using UnityEngine;
using System.Collections;

public class breakLight : MonoBehaviour {

	public Light lt;
	// Use this for initialization
	void Start () {
		lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			lt.intensity = 7;
		} else {
			lt.intensity = 1;
		}
	}
}
